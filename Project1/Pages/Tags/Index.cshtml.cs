using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project1.Data;
using Project1.Models;

namespace Project1.Pages.Tags
{
    public class IndexModel : PageModel
    {
        private readonly Project1.Data.Project1Context _context;

        public IndexModel(Project1.Data.Project1Context context)
        {
            _context = context;
        }

        public IList<Tag> Tag { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Tags != null)
            {
                Tag = await _context.Tags.ToListAsync();
            }
        }
    }
}
