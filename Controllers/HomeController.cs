using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingPlannerRadhin.Models;
//added these line
using Microsoft.AspNetCore.Http;
using System.Text;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Globalization;


namespace WeddingPlannerRadhin.Controllers
{
    public class HomeController : Controller
    {
        private WeddingPlannerRadhinContext dbContext;

        // here we can "inject" our context service into the constructor
        public HomeController(WeddingPlannerRadhinContext context)
        {
            dbContext = context;
        }
        //////////////////////////////////////////////////////////////////////
        /////////////////START LOGIN AND REGISTRATION/////////////////////////
        //////////////////////////////////////////////////////////////////////
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult create(User newUser)
        {
            System.Console.WriteLine(newUser.FirstName);
            if (ModelState.IsValid)
            {
                if (dbContext.Users.Any(u => u.Email == newUser.Email))
                {
                    // Manually add a ModelState error to the Email field, with provided
                    // error message
                    ModelState.AddModelError("Email", "Email already in use!");
                    System.Console.WriteLine("there");
                    return View("Index");

                    // You may consider returning to the View at this point
                }
                // Initializing a PasswordHasher object, providing our User class as its
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                //Save your user object to the database
                System.Console.WriteLine("here");
                // We can take the User object created from a form submission
                // And pass this object to the .Add() method
                dbContext.Add(newUser);
                // OR dbContext.Users.Add(newUser);
                dbContext.SaveChanges();
                // Other code
                HttpContext.Session.SetInt32("User", 1);
                HttpContext.Session.SetInt32("userInSession", newUser.UserId);
                HttpContext.Session.SetString("userInSession_firstname", newUser.FirstName);
                HttpContext.Session.SetString("userInSession_lastname", newUser.LastName);
                return RedirectToAction("account", new { id = newUser.UserId });
            }
            else
            {
                return View("Index");
            }

        }
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost("loginVerification")]
        public IActionResult loginVerification(LoginUser userSubmission)
        {
            if (ModelState.IsValid)
            {
                // If inital ModelState is valid, query for a user with provided email
                var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == userSubmission.Email);
                // If no user exists with provided email
                if (userInDb == null)
                {
                    // Add an error to ModelState and return to View!
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("Login");
                }

                // Initialize hasher object
                var hasher = new PasswordHasher<LoginUser>();

                // varify provided password against hash stored in db
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);

                // result can be compared to 0 for failure
                if (result == 0)
                {
                    // handle failure (this should be similar to how "existing email" is handled)
                    ModelState.AddModelError("Password", "Invalid Password");
                    return View("Login");
                }
                HttpContext.Session.SetInt32("User", 1);
                HttpContext.Session.SetInt32("userInSession", userInDb.UserId);
                HttpContext.Session.SetString("userInSession_firstname", userInDb.FirstName);
                HttpContext.Session.SetString("userInSession_lastname", userInDb.LastName);
                return RedirectToAction("account", new { id = userInDb.UserId });
            }
            else
            {
                return View("Login");
            }
        }
        [HttpGet("logout")]
        public IActionResult Logout() //logout button must have its own function because it has to clear session when the user logs out
        {
            HttpContext.Session.Clear();
            return View("Index");
        }
        //////////////////////////////////////////////////////////////////////
        /////////////////FROM ABOVE IS LOGIN AND REGISTRATION/////////////////
        /////////////////FROM BELOW IS START OF WEDDING PLANNER///////////////
        //////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////
        ////////////////////////////ACCOUT PAGE///////////////////////////////
        //////////////////////////////////////////////////////////////////////
        [HttpGet("account/{id}")]
        public IActionResult Account()
        {
            if (HttpContext.Session.GetInt32("userInSession") == null)
            {
                return View("Index");
            }
            User CurrentUser = dbContext.Users.SingleOrDefault(UserModel => UserModel.UserId == HttpContext.Session.GetInt32("userInSession"));

            List<Wedding> listOfWeddings = dbContext.Weddings
            .Include(WeddingModel => WeddingModel.listOfGuests)
            .ThenInclude(RSVPModel => RSVPModel.User)
            .ToList();

            IEnumerable<Wedding> List_in_order = listOfWeddings.OrderBy(WeddingModel => WeddingModel.Date);
            
            ViewBag.listOfWeddings = listOfWeddings;

            ViewBag.id = HttpContext.Session.GetInt32("userInSession");

            ViewBag.User = dbContext.Users.FirstOrDefault(UserModel => UserModel.UserId == HttpContext.Session.GetInt32("userInSession"));
            
            return View();
        }
        //////////////////////////////////////////////////////////////////////
        ////////////////////////////WEDDING FORM PAGE/////////////////////////
        //////////////////////////////////////////////////////////////////////
        [HttpGet("weddingform")]
        public IActionResult WeddingForm()
        {
            if (HttpContext.Session.GetInt32("userInSession") == null)
            {
                return View("Index");
            }
            User userInSession = dbContext.Users.FirstOrDefault(UserModel => UserModel.UserId == HttpContext.Session.GetInt32("userInSession"));//What is this??

            ViewBag.user = HttpContext.Session.GetInt32("userInSession");

            return View();
        }
        //////////////////////////////////////////////////////////////////////
        /////////////////////////WEDDING INFO PAGE////////////////////////////
        //////////////////////////////////////////////////////////////////////
        [HttpGet("wedding/{wid}")]
        public IActionResult WeddingInfo(int wid)
        {
            if (HttpContext.Session.GetInt32("userInSession") == null)
            {
                return View("Index");
            }
            ViewBag.User = dbContext.Users.FirstOrDefault(UserModel => UserModel.UserId == HttpContext.Session.GetInt32("userInSession"));
            
            ViewBag.wedding = dbContext.Weddings
            .Include(WeddingModel => WeddingModel.listOfGuests)
            .ThenInclude(RSVPModel => RSVPModel.User)
            .FirstOrDefault(WeddingModel => WeddingModel.WeddingId == wid);

            return View();
        }
        //////////////////////////////////////////////////////////////////////
        //////////////////////ADD A WEDDING FORM BUTTON///////////////////////
        //////////////////////////////////////////////////////////////////////
        [HttpPost("addwedding")]
        public IActionResult AddWedding(Wedding wed)
        {
            System.Console.WriteLine(wed.Bride);
            System.Console.WriteLine(wed.Groom);

            System.Console.WriteLine(wed.Date);
            System.Console.WriteLine(wed.Address);

            DateTime CurrentTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                System.Console.WriteLine("-------2-------");

                if (DateTime.Parse(Request.Form["Date"]) < CurrentTime)
                {
                    ModelState.AddModelError("Date", "Date Cannot be in the past");
                    User userInSession = dbContext.Users.FirstOrDefault(UserModel => UserModel.UserId == HttpContext.Session.GetInt32("userInSession"));//What is this??

                    ViewBag.user = HttpContext.Session.GetInt32("userInSession");
                    return View("WeddingForm");
                }
                else
                {
                    Wedding newWed = wed;
                    newWed.User = dbContext.Users.FirstOrDefault(UserModel => UserModel.UserId == wed.UserId);
                    dbContext.Add(newWed);
                    dbContext.SaveChanges();
                    return RedirectToAction("Account", new { id = HttpContext.Session.GetInt32("userInSession") });
                }
            }
            else
            {
                System.Console.WriteLine("-------3-------");
                User userInSession = dbContext.Users.FirstOrDefault(UserModel => UserModel.UserId == HttpContext.Session.GetInt32("userInSession"));//What is this??

                ViewBag.user = HttpContext.Session.GetInt32("userInSession");
                return View("WeddingForm");
            }
        }
            //////////////////////////////////////////////////////////////////////
            ///////////////////////////ADD RSVP BUTTON////////////////////////////
            //////////////////////////////////////////////////////////////////////
        [HttpGet("rsvp/{wid}/{uid}")]
        public IActionResult AddRSVP(int wid, int uid)
        {

            Wedding newWed = dbContext.Weddings.Include(a => a.listOfGuests).ThenInclude(b => b.User).FirstOrDefault(wed => wed.WeddingId == wid);
            User newUser = dbContext.Users.Include(a => a.listOfReservations).ThenInclude(b => b.Wedding).FirstOrDefault(us => us.UserId == uid);

            foreach(var wedding in newUser.listOfReservations)
            {
                if(wedding.Wedding.Date.Date == newWed.Date.Date)
                {
                    ModelState.AddModelError("WeddingDate", "Date Cannot be in the past");

                    return RedirectToAction("Account", new { id = HttpContext.Session.GetInt32("userInSession") });
                }
            }

            RSVP add = new RSVP();
            add.WeddingId = wid;
            add.UserId = uid;
            add.User = dbContext.Users.FirstOrDefault(UserModel => UserModel.UserId == uid);
            add.Wedding = dbContext.Weddings.FirstOrDefault(WeddingModel => WeddingModel.WeddingId == wid);
            dbContext.Add(add);
            dbContext.SaveChanges();
            return RedirectToAction("Account", new { id = HttpContext.Session.GetInt32("userInSession") });
        }
            //////////////////////////////////////////////////////////////////////
            ////////////////////////ADD UN-RSVP BUTTON////////////////////////////
            //////////////////////////////////////////////////////////////////////
        [HttpGet("cancel/{id}")]
        public IActionResult DeleteRSVP(int id)
        {
            RSVP canceled = dbContext.RSVPs.FirstOrDefault(RSVPModel => RSVPModel.RSVPId == id);
            dbContext.Remove(canceled);
            dbContext.SaveChanges();
            
            return RedirectToAction("Account", new { id = HttpContext.Session.GetInt32("userInSession") });
        }
            //////////////////////////////////////////////////////////////////////
            //////////////////////DELETE A WEDDING BUTTON/////////////////////////
            //////////////////////////////////////////////////////////////////////
        [HttpGet("delete/{wid}")]
        public IActionResult Delete(int wid)
        {
            Wedding deleted = dbContext.Weddings.FirstOrDefault(WeddingModel => WeddingModel.WeddingId == wid);
            dbContext.Remove(deleted);
            dbContext.SaveChanges();

            return RedirectToAction("Account", new { id = HttpContext.Session.GetInt32("userInSession") });//I have a delete problem
        }
    }
}
