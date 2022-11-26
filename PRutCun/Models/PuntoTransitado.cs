using PRutCun.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRutCun.Models
{
    public class PuntoTransitado
    {
        //rutcun
        [Key]
        public int FkPunto { get; set; }
        [Key]
        public int FkTrasporte { get; set; }

        [ForeignKey("FkPunto")]
        public PuntoInteres Punto { get; set; }

        [ForeignKey("FkTrasporte")]
        public Trasporte Trasporte { get; set; }

    }
}
