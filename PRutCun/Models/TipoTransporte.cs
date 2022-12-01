using System.ComponentModel.DataAnnotations;

namespace PRutCun.Models
{
    public class TipoTransporte
    {
        [Key]
        public int PkTipo { get; set; }
        public string Nombre { get; set; }
    }
}
