using Microsoft.EntityFrameworkCore;

namespace BookStoreMVC.Models
{
    public class DataBaseContext: DbContext
    {
        public DataBaseContext()
        {
        }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<Autor> Autores { get; set; }
        public virtual DbSet<Editorial> Editoriales { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }

    }
}
