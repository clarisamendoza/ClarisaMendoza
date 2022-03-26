using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClarisaMendoza.Models
{
    public class Pagos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPago { get; set; }
        public int IdPrestamo { get; set; }
        public Prestamo Prestamo { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoPagado { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaPago { get; set; }
    }
}
