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
        public int FkTransporte { get; set; }

        [ForeignKey("FkPunto")]
        public PuntoInteres Punto { get; set; }

        [ForeignKey("FkTransporte")]
        public Transporte Transporte { get; set; }

    }
}
