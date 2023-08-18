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
    public class DeleteModel : PageModel
    {
        private readonly Project1.Data.Project1Context _context;

        public DeleteModel(Project1.Data.Project1Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Tag Tag { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tags == null)
            {
                return NotFound();
            }

            var tag = await _context.Tags.FirstOrDefaultAsync(m => m.TagID == id);

            if (tag == null)
            {
                return NotFound();
            }
            else 
            {
                Tag = tag;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Tags == null)
            {
                return NotFound();
            }
            var tag = await _context.Tags.FindAsync(id);

            if (tag != null)
            {
                Tag = tag;
                _context.Tags.Remove(Tag);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
