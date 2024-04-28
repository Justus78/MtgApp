using MagicApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MagicApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } // end index action

        public IActionResult SuperTypes()
        {
            return View();
        } // end action

        public IActionResult CardTypes()
        {
            return View();
        } // end action

        public IActionResult Colors()
        {
            return View();
        } // end action

        public IActionResult Formats()
        {
            return View();
        } // end action

        public IActionResult Standard()
        {
            return View();
        } // end action

        public IActionResult Modern()
        {
            return View();
        } // end action

        public IActionResult Legacy()
        {
            return View();
        } // end action

        public IActionResult Vintage()
        {
            return View();
        } // end action

        public IActionResult Commander()
        {
            return View();
        } // end action


    } // end controller
} // end namespace
