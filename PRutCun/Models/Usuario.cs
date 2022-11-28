using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PRutCun.Models
{
    public class Usuario
    {
        [Key]
        public int PkUser { get; set; }
        public string Nombre { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }

        [ForeignKey("FkRol")]
        public int? FkRol { get; set; }
        public Roles Rol { get; set; }
    }
}
