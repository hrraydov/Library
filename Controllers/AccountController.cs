using Library.Services;
using Library.Services.Interfaces;
using Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class AccountController : BaseController
    {
        private IUserService userService;

        public AccountController()
        {
            this.userService = new UserService();
        }

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register([Bind(Exclude = "IsAuthenticated")]RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            if (this.userService.UsernameExists(viewModel.Username))
            {
                ModelState.AddModelError("", "Username exists");
                return View(viewModel);
            }
            this.userService.Create(new Models.User
            {
                Username = viewModel.Username,
                Password = viewModel.Password
            });
            return RedirectToAction("Login");

        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Exclude = "IsAuthenticated")]LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = this.userService.GetByUsernameAndPassword(viewModel.Username, viewModel.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "username does not exists");
                return View(viewModel);
            }

            Session["userId"] = user.Id;
            Session["isAuthenticated"] = true;

            return RedirectToAction("Index", "Books");

        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["userId"] = null;
            Session["isAuthenticated"] = false;
            return Redirect("/");
        }
    }
}