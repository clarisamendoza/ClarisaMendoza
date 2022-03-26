using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClarisaMendoza.Models
{
    public class Prestamo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPrestamo { get; set; }

        [Required(ErrorMessage = "Este campo es requirido")]
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }

        [Required(ErrorMessage = "Este campo es requirido")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "Este campo es requirido")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Interes { get; set; }

        [Required(ErrorMessage = "Este campo es requirido")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Plazo { get; set; }

        [Required(ErrorMessage = "Este campo es requirido")]
        [StringLength(10)]
        public string EstadoPrestamo { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaCreacion { get; set; }


    }
}
