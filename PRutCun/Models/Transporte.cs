using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRutCun.Models
{
    public class Transporte
    {
        [Key]
        public int PkTransporte { get; set; }

        public string Nombre { get; set; }
        public string HoraInicial { get; set;}
        public string HoraFinal { get; set; }
        public string Dia { get; set; }
        public bool Estatus { get; set; }

        [ForeignKey ("Tipo")]
        public int? FkTipo { get; set; }
        public TipoTransporte Tipo { get; set; }

    }
}
