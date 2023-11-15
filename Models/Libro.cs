using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStoreMVC.Models
{       
    [Table("Libro")]
        public class Libro
        {
            [Key]
            [Column("ID")]
            public int Id { get; set; }

            [Display(Name = "Imagen")]
            public string? ImagenLibro { get; set; }

            [Display(Name = "Titulo")]
            [StringLength(50)]
            public string? Titulo { get; set; }

            [Display(Name = "Genero")]
            public int? GeneroRefId { get; set; }
            [ForeignKey("GeneroRefId")]
            public virtual Genero? Genero { get; set; }

            [Display(Name = "Autor")]
            public int? AutorRefId { get; set; }
            [ForeignKey("AutorRefId")]
            public virtual Autor? Autor { get; set; }

            [Display(Name = "Editorial")]
            public int? EditorialRefId { get; set; }
            [ForeignKey("EditorialRefId")]
            public virtual Editorial? Editorial { get; set; }

            [Display(Name = "Precio")]
            public int? Precio { get; set; }

            [Display(Name = "Nro de Paginas")]
            public int? NroPaginas { get; set; }
            
           

    }
    }

