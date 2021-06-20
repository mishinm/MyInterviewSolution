using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext _context;
        private readonly HomeServices _homeServices;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context, HomeServices homeServices)
        {
            _logger = logger;
            _context = context;
            _homeServices = homeServices;
        }

        public IActionResult Index()
        {
            return View(_homeServices.GetUserInfoViewModel());
        }       

        [HttpPost]
        public IActionResult Index(UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.UserInfos.Add(userInfo);
                    _context.SaveChanges();
                    ModelState.Clear();
                    ViewData["JavaScript"] = "window.location = '" + Url.Page("/Index") + "'";
                }
                catch (Exception exc)
                {
                    _logger.LogError(exc.Message);
                    return View("Error", new ErrorViewModel() { RequestId = exc.Message });
                }               
            }
            return View();
        }

        public IActionResult Delete()
        {
            try
            {
                _context.UserInfos.RemoveRange(_context.UserInfos);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return View("Error", new ErrorViewModel() { RequestId = e.Message });
            }
            return View("Index",_homeServices.GetUserInfoViewModel());
        }
    }
}
