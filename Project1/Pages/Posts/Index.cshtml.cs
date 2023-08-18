using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project1.Data;
using Project1.Models;

namespace Project1.Pages.Posts
{
    public class IndexModel : PageModel
    {
        private readonly Project1.Data.Project1Context _context;

        public IndexModel(Project1.Data.Project1Context context)
        {
            _context = context;
        }

        public IList<Post> Post { get;set; } = default!;

        [BindProperty]
        public string? SearchString { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Posts != null)
            {
                Post = await _context.Posts
                .Include(p => p.Author).ToListAsync();
            }
        }

        public IActionResult OnPostSearch()
        {
            if (SearchString == null)
            {
                Post = _context.Posts
               .Include(p => p.Author).ToList();
            }
            else
            {
                Post = _context.Posts
                    .Where(b => b.Title.Contains(SearchString))
                    .Include(b => b.Author)
                    .ToList();
            }

            return Page();
        }


    }
}
