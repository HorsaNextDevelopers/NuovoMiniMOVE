using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthSystem.Models
{
    public class DistintaComponente
    {
        public string CodiceArticolo { get; set; }
        [ForeignKey("CodiceArticolo ")]
        public Articolo Articoli { get; set; }

        [Key]
        [Column(TypeName = "nvarchar(128)")]
        public string CodiceComponente { get; set; }
        
        [Column(TypeName = "nvarchar(250)")]
        public string Descrizione { get; set; }

       public int Quantita { get; set; }







    }
}
