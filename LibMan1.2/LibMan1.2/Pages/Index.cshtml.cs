using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibMan1._2.Models.DB;
using Microsoft.AspNetCore.Http;

namespace LibMan1._2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly LibMan1._2.Models.DB.LibManContext _context;

        public IndexModel(LibMan1._2.Models.DB.LibManContext context)
        {
            _context = context;
        }

        public IList<TableUserInfo> TableUserInfo { get;set; }

        public async Task OnGetAsync()
        {
            TableUserInfo = await _context.TableUserInfo.ToListAsync();
        }

        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public string Msg { get; set; }

        private bool CustomersExists(string username, string password)
        {
            bool usern = false, pass = false;
            usern = _context.TableUserInfo.Any(e => e.UserName == username);
            pass = _context.TableUserInfo.Any(e => e.Password == password);
            if (usern == true && pass == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool AdminExists(int id, string password)
        {
            bool admin = false, apass = false;
            admin = _context.TableAdminInfo.Any(e => e.Id == id);
            apass = _context.TableAdminInfo.Any(e => e.Password == password);
            if (admin == true && apass == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IActionResult OnPost()
        {
            if (CustomersExists(Username, Password))
            {
                var cust = _context.TableUserInfo.Single(a => a.UserName == Username);
                HttpContext.Session.SetString("username", cust.Name);
                return RedirectToPage("ListUser");
            }
            else if (AdminExists(Convert.ToInt32(Username), Password))
            {
                HttpContext.Session.SetString("username", Username);
                return RedirectToPage("ListUserAdmin");
            }
            else
            {
                Msg = "Invalid";
                return Page();
            }
        }
    }
}
