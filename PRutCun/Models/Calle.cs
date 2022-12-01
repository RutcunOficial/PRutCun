using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRutCun.Models
{
    public class Calle
    {
        [Key]
        public int PkCalle { get; set; }

        public string NombreCalle { get; set; }
    }
}
