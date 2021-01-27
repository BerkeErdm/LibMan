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
    public class ListBookModel : PageModel
    {
        private readonly LibMan1._2.Models.DB.LibManContext _context;

        public ListBookModel(LibMan1._2.Models.DB.LibManContext context)
        {
            _context = context;
        }

        public IList<TableBookInfo> TableBookInfo { get;set; }
        public async Task OnGetAsync()
        {
            TableBookInfo = await _context.TableBookInfo.ToListAsync();
        }

    }
}
