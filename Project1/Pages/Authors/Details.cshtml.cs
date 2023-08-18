using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project1.Data;
using Project1.Models;

namespace Project1.Pages.Authors
{
    public class DetailsModel : PageModel
    {
        private readonly Project1.Data.Project1Context _context;

        public DetailsModel(Project1.Data.Project1Context context)
        {
            _context = context;
        }

      public Author Author { get; set; } = default!;
        public List<Post> Posts { get; set; } = new List<Post>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var author = await _context.Authors.FirstOrDefaultAsync(m => m.AuthorID == id);
            if (author == null)
            {
                return NotFound();
            }
            else 
            {
                Author = author;
            }

            Posts = await _context.Posts
                .Where(p => p.AuthorId == id)
                .ToListAsync();


            return Page();
        }
    }
}
