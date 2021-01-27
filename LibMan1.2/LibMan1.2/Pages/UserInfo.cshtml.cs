using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibMan1._2.Models.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibMan1._2.Pages
{
    public class UserInfoModel : PageModel
    {
        private readonly LibMan1._2.Models.DB.LibManContext _context;
        public UserInfoModel(LibMan1._2.Models.DB.LibManContext context)
        {
            _context = context;
        }
        [BindProperty]
        public string Username { get; set; }
        public void OnGet()
        {
            Username = HttpContext.Session.GetString("username");
        }
        [BindProperty]
        public TableUserInfo UserInfo { get; set; }
        private bool TableUserInfoExists(String Username)
        {
            return _context.TableUserInfo.Any(e => e.UserName == Username);
        }
        public void Save(TableUserInfo user)
        {
            _context.TableUserInfo.Update(user); _context.SaveChanges();
        }

        public IActionResult OnPostRegister()
        {

           
            string userr = Request.Form["UserName"];
            string pass = Request.Form["Password"];
            string mail = Request.Form["Mail"];
            string name = Request.Form["Name"];
            string surname = Request.Form["SurName"];
            string date = Request.Form["Date"];

            string username = HttpContext.Session.GetString("username");
            var User = _context.TableUserInfo.Single(a => a.UserName == username);

            User.UserName = userr;
            User.Password = pass;
            User.Mail = mail;
            User.Name = name; ;
            User.SurName = surname;
            User.Date = date;

            _context.SaveChanges();

            return RedirectToPage();

        }

    }
}