using Microsoft.EntityFrameworkCore;
using NoteWebApp.Models;

namespace NoteWebApp.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Note> Notes { get; set; }
    }
}
