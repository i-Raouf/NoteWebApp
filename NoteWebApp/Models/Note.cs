using System.ComponentModel.DataAnnotations;

namespace NoteWebApp.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title can't be empty.")]
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime LastModified { get; set; } = DateTime.Now;
    }
}
