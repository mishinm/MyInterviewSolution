using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Helper;

namespace WebApplication1.Models
{
    public class UserInfo
    {
        public int UserInfoId { get; set; }

        [CustomRequired()]
        [Display(Name = "Имя")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [CustomRequired()]
        [Display(Name = "Фамилия")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
    }
}
