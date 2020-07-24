using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientesApp.API.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Cliente { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Identificacion { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Nombre { get; set; }
        public bool Genero { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        [ForeignKey("EstadoCivilID")]
        public int EstadoCivilID { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
    }
}