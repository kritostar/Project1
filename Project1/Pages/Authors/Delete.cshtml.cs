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
    public class DeleteModel : PageModel
    {
        private readonly Project1.Data.Project1Context _context;

        public DeleteModel(Project1.Data.Project1Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Author Author { get; set; } = default!;

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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }
            var author = await _context.Authors.FindAsync(id);

            if (author != null)
            {
                Author = author;
                _context.Authors.Remove(Author);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
