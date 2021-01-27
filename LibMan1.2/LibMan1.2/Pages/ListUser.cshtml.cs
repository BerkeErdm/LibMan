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
    public class ListUserModel : PageModel
    {
        private readonly LibMan1._2.Models.DB.LibManContext _context;

        public ListUserModel(LibMan1._2.Models.DB.LibManContext context)
        {
            _context = context;
        }

        public IList<TableUserInfo> TableUserInfo { get;set; }

        public async Task OnGetAsync()
        {
            TableUserInfo = await _context.TableUserInfo.ToListAsync();
        }
    }
}
