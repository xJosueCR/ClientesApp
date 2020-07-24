using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientesApp.API.Models
{
    public class EstadoCivil
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EstadoCivilID { get; set; }
        public string Descripcion { get; set; }
        public List<Cliente> Clientes { get; set; }
    }
}