using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BookStoreMVC.Models;

namespace BookStoreMVC.ViewModel
{
    public class LibroViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor, ingresar el Titulo.")]
        [Display(Name = "Titulo")]
        public string? Titulo { get; set; }

        [Display(Name = "Precio")]
        public int? Precio { get; set; }

        [Display(Name = "Nro de Paginas")]
        public int? NroPaginas { get; set; }

        [Display(Name = "Genero")]
        public int? GeneroRefId { get; set; }

        public virtual Genero? Genero { get; set; }

        [Display(Name = "Autor")]
        public int? AutorRefId { get; set; }

        public virtual Autor? Autor { get; set; }

        [Display(Name = "Editorial")]
        public int? EditorialRefId { get; set; }
        public virtual Editorial? Editorial { get; set; }

        [Display(Name = "Fecha Registro")]
        [DataType(DataType.Date)]
        public DateTime? FechaRegistro { get; set; }

        [Display(Name = "Imagen Libro")]
        public IFormFile Imagem { get; set; }

        [Display(Name = "Imagen")]
        public string? ImagenLibro { get; set; }
    }
}
