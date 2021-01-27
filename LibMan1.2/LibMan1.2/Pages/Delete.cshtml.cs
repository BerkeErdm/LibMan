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
    public class DeleteModel : PageModel
    {
        private readonly LibMan1._2.Models.DB.LibManContext _context;

        public DeleteModel(LibMan1._2.Models.DB.LibManContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TableBookInfo = await _context.TableBookInfo.FindAsync(id);

            if (TableBookInfo != null)
            {
                _context.TableBookInfo.Remove(TableBookInfo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./ListBook");
        }
    }
}
