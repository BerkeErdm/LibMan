using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibMan1._2.Models.DB;

namespace LibMan1._2.Pages
{
    public class EditModel : PageModel
    {
        private readonly LibMan1._2.Models.DB.LibManContext _context;

        public EditModel(LibMan1._2.Models.DB.LibManContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TableBookInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableBookInfoExists(TableBookInfo.BookId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./ListBook");
        }

        private bool TableBookInfoExists(int id)
        {
            return _context.TableBookInfo.Any(e => e.BookId == id);
        }
    }
}
