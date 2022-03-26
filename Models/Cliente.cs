using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClarisaMendoza.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Este campo es requirido")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es requirido")]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Este campo es requirido")]
        [StringLength(20)]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Este campo es requirido")]
        [StringLength(100)]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Este campo es requirido")]
        [StringLength(20)]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Este campo es requirido")]
        [StringLength(20)]
        public string Cedula { get; set; }

        public int IdUsuario { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaCreacion { get; set; }

    }
}
