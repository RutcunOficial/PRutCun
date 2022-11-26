using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRutCun.Models
{
    public class Mapas
    {
        [Key]
        public int PkMapas { get; set; }
        public string MapaUrl { get; set; }

        [ForeignKey("FkTrasporte")]
        public Trasporte Trasporte { get; set; }

    }
}
