﻿using System;
using System.Collections.Generic;
using RpgInfinity.Models.Repos;
using RpgInfinity.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RpgInfinity.Controllers
{
    public class HomeController : Controller
    {
        public static User _currentUser = null;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Login Page";

            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            try
            {
                var repo = new UserRepo();

                var logUser = repo.LoginUser(user);

                if (logUser == null)
                {
                    ViewBag.ErrorMessage = "Username or Password was incorrect";
                    return View();
                }

                _currentUser = logUser;

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return View();
            }
        }

        public ActionResult SignUp()
        {
            ViewBag.Message = "Create Account Page";

            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            try
            {
                var repo = new UserRepo();

                var isNewUser = repo.SignUp(user);

                if (!isNewUser)
                {
                    ViewBag.ErrorMessage = "User already exists";
                    return View();
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return View();
            }
        }

        public ActionResult Logout()
        {
            _currentUser = null;

            return View("Index");
        }
    }
}