using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRutCun.Models
{
    public class CalleTransitada
    {
        [Key]
        public int FkCalle { get; set; }
        [Key]
        public int FkTrasporte { get; set; }

        [ForeignKey("FkCalle")]
        public Calle Calle { get; set; }

        [ForeignKey("FkTrasporte")]
        public Trasporte Trasporte { get; set; }
    }
}
