using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibMan1._2.Models.DB;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace LibMan1._2.Pages
{
    public class BookInfoModel : PageModel
    {
        private readonly LibMan1._2.Models.DB.LibManContext _context;
        private readonly IHostingEnvironment _environment;
        public BookInfoModel(LibMan1._2.Models.DB.LibManContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public string Username { get; set; }
        public IActionResult OnGet()
        {
            Username = HttpContext.Session.GetString("username");
            return Page();
        }

        [BindProperty]
        public TableBookInfo TableBookInfo { get; set; }
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    //string username = HttpContext.Session.GetString("username");
        //    //var User = _context.TableUserInfo.Single(a => a.UserName == username);

        //    _context.TableBookInfo.Add(TableBookInfo);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./Index");
        //}

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TableBookInfo.Add(TableBookInfo);
            string resimler = Path.Combine(_environment.WebRootPath, "resimler");
            if (TableBookInfo.ImageFile.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(resimler, TableBookInfo.ImageFile.FileName), FileMode.Create))
                {
                    await TableBookInfo.ImageFile.CopyToAsync(fileStream);
                }
            }
            TableBookInfo.Imagee = TableBookInfo.ImageFile.FileName;
            await _context.SaveChangesAsync();

            return RedirectToPage("./ListBook");
        }
    }
}

