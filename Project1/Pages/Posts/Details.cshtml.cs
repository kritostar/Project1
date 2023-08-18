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
    public class DetailsModel : PageModel
    {
        private readonly Project1.Data.Project1Context _context;

        public DetailsModel(Project1.Data.Project1Context context)
        {
            _context = context;
        }

      public Post Post { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }


            var post = await _context.Posts
                .Include(b => b.Author)
                .Include(b => b.PostTags)
                    .ThenInclude(b => b.Tag)
                .FirstOrDefaultAsync(m => m.PostID == id);

            if (post == null)
            {
                return NotFound();
            }
            else 
            {
                Post = post;
            }
            return Page();
        }
    }
}
