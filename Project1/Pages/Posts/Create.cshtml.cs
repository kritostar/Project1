using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project1.Data;
using Project1.Models;

namespace Project1.Pages.Posts
{
    public class CreateModel : PageModel
    {
        private readonly Project1.Data.Project1Context _context;

        public CreateModel(Project1.Data.Project1Context context)
        {
            _context = context;
        }

        public SelectList AuthorsSelectList { get; set; }
        [BindProperty]
        public int[] SelectedTagIDs { get; set; }
        public MultiSelectList TagsSelectList { get; set; }

        public IActionResult OnGet()
        {
            AuthorsSelectList = new SelectList(_context.Authors, "AuthorID", "AuthorName");
            TagsSelectList = new MultiSelectList(_context.Tags, "TagID", "TagName");
            return Page();
        }

        [BindProperty]
        public Post Post { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Posts == null || Post == null)
            {
                return Page();
            }

            _context.Posts.Add(Post);
            await _context.SaveChangesAsync();

            // make a list of PostTags objects
            List<PostTag> postTag = new List<PostTag>();

            // loop for each id on the list
            foreach (int id in SelectedTagIDs)
            {
                postTag.Add(new PostTag
                {
                    PostID = Post.PostID,
                    TagID = id
                });
            }

            // update the context with the list
            _context.PostTags.AddRange(postTag);
            _context.SaveChanges();


            return RedirectToPage("./Index");
        }
    }
}
