using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRutCun.Models
{
    public class CalleTransitada
    {
        [Key]
        public int FkCalle { get; set; }
        [Key]
        public int FkTransporte { get; set; }

        [ForeignKey("FkCalle")]

        public Calle Calle { get; set; }

        [ForeignKey("FkTransporte")]

        public Transporte Transporte { get; set; }
    }
}
