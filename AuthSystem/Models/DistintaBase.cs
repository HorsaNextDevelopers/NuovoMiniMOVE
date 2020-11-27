using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthSystem.Models
{
    public class DistintaBase
    {
        [Key]
        public int IdDistintaBase { get; set; }
        public string CodicePadre { get; set; }
        [ForeignKey("CodiceArticolo ")]
        public Articolo Articoli { get; set; }
        public int CodiceFiglio { get; set; }
        [ForeignKey("IdDistintaBase ")]
        public DistintaBase DistintaBases { get; set; }
        public int Quantità { get; set; }
    }
}