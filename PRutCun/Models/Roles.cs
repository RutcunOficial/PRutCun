
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRutCun.Models
{
    public class Roles
    {
            [Key]
            public int PkRol { get; set; }

            public string Nombre { get; set; }
        
    }
}
