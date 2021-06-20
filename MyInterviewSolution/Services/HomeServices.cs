using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class HomeServices
    {
        private readonly ApplicationContext _context;

        public HomeServices(ApplicationContext context)
        {
            _context = context;
        }

        public UserInfoViewModel GetUserInfoViewModel()
        {
            var list = _context.UserInfos.OrderByDescending(d=>d.UserInfoId).ToList();
            UserInfoViewModel userInfoViewModel = new UserInfoViewModel
            {
                UserInfos = list
            };
            return userInfoViewModel;
        }
    }
}
