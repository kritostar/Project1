using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Project1.Models
{
    public class Author
    {

        public int AuthorID { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public List<Post>? ListOfPosts { get; set; }


    }
    public class Post
    {
        public int PostID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string PostText { get; set; } = string.Empty;
        public DateTime? DatePublished { get; set; }

        public int AuthorId { get; set; }// foreign key
        public Author? Author { get; set; }// navigation
        public List<PostTag>? PostTags { get; set; } // navigation

    }

    public class Tag
    {
        public int TagID { get; set; }
        public string TagName { get; set; } = string.Empty;

        public List<PostTag>? PostTags { get; set; }


    }

    public class PostTag 
    {
        public int PostID { get; set; }
        public Post? Post { get; set; }

        public int TagID { get; set; }
        public Tag? Tag { get; set; }
    }


}
