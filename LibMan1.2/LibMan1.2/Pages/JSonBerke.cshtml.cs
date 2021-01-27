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
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;

namespace LibMan1._2.Pages
{
    public class JSonBerkeModel : PageModel
    {
        private readonly LibMan1._2.Models.DB.LibManContext _context;
        private readonly IHostingEnvironment _environment;
        public JSonBerkeModel(LibMan1._2.Models.DB.LibManContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }


        public class FileInputModel
        {
            public string Name { get; set; }
            public IFormFile FileToUpload { get; set; }

        }



        [BindProperty]
        public IFormFile Image { set; get; }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]

        public TableBookInfo TableBookInfo { get; set; }

        [HttpPost("FileUpload")]

        public async Task<IActionResult> OnPostAsync()
        {
            if (this.Image != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);

                //Get url To Save
                string SavePath = Path.Combine(_environment.WebRootPath, "json/jsonImport", Image.FileName);

                using (var stream = new FileStream(SavePath, FileMode.Create))
                {
                    stream.Position = 0;
                    stream.Flush();
                    Image.CopyTo(stream);
                }

                string contentRootPath = Path.Combine(_environment.WebRootPath, "json/jsonImport", Image.FileName);

                var JSON = System.IO.File.ReadAllText(contentRootPath);

                List<TableBookInfo> products = JsonConvert.DeserializeObject<List<TableBookInfo>>(JSON);
                foreach (var item in products)
                {
                    _context.TableBookInfo.Add(item);
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToPage("./ListBook");
        }
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (this.Image != null)
        //    {
        //        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);

        //        //Get url To Save
        //        string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/json/jsonImport", fileName);
        //        using (var stream = new FileStream(SavePath, FileMode.Create))
        //        {
        //            Image.CopyTo(stream);
        //        }

        //        string contentRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/json/jsonImport", Image.FileName);

        //        var JSON = System.IO.File.ReadAllText(contentRootPath);

        //        List<TableBookInfo> products = JsonConvert.DeserializeObject<List<TableBookInfo>>(JSON);
        //        foreach (var m in products)
        //        {
        //            _context.TableBookInfo.Add(m);
        //            await _context.SaveChangesAsync();
        //        }

        //    }

        //    return RedirectToPage("./ListBook");
        //}


        /*
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TableBookInfo.Add(TableBookInfo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }*/
    }
}
