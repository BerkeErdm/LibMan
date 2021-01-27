using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibMan1._2.Models.DB;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace LibMan1._2.Pages
{
    public class CreateModel : PageModel
    {
        private readonly LibMan1._2.Models.DB.LibManContext _context;
        private readonly IHostingEnvironment _environment;

        public CreateModel(LibMan1._2.Models.DB.LibManContext context , IHostingEnvironment environment )
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TableUserInfo TableUserInfo { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TableUserInfo.Add(TableUserInfo);
            string resimler = Path.Combine(_environment.WebRootPath, "resimler");
            if (TableUserInfo.PhotoFile.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(resimler, TableUserInfo.PhotoFile.FileName), FileMode.Create))
                {
                    await TableUserInfo.PhotoFile.CopyToAsync(fileStream);
                }
            }
            TableUserInfo.PhotoPath = TableUserInfo.PhotoFile.FileName;
            await _context.SaveChangesAsync();

            return RedirectToPage("./ListUser");
        }

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.TableUserInfo.Add(TableUserInfo);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./ListBook");
        //}
    }
}