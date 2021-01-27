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
    public class DetailsModel : PageModel
    {
        private readonly LibMan1._2.Models.DB.LibManContext _context;

        public DetailsModel(LibMan1._2.Models.DB.LibManContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TableBookInfo TableBookInfo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TableBookInfo = await _context.TableBookInfo.FirstOrDefaultAsync(m => m.BookId == id);

            if (TableBookInfo == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
