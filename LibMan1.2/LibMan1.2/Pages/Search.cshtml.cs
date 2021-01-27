using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibMan1._2.Models.DB;

namespace LibMan1._2.Pages
{
    public class SearchModel : PageModel
    {
        private readonly LibMan1._2.Models.DB.LibManContext _context;

        public SearchModel(LibMan1._2.Models.DB.LibManContext context)
        {
            _context = context;
        }

        public IList<TableBookInfo> TableBookInfo { get;set; }

        public async Task<IActionResult> OnGetAsync(String aranacak)
        {

            if (aranacak == null)
            {
                return NotFound();
            }


            TableBookInfo = await _context.TableBookInfo
                .Where(b => b.BookName == aranacak)
                .ToListAsync();

            return Page();
        }
    }
}
