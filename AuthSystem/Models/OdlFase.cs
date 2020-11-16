using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Models
{
    public class OdlFase
    {
        [Key]
        [Column(TypeName = "nvarchar(128)")]
        public string CodiceOdl { get; set; }
        [ForeignKey("CodiceOdl")]
        public Odl Odls { get; set; }
        public string CodiceArticolo { get; set; }
        [ForeignKey("CodiceArticolo ")]
        public Articolo Articoli { get; set; }
        public int FaseOdl { get; set; }
        public string CodiceCentroDiLavoro { get; set; }
        [ForeignKey("CodiceCentroDiLavoro ")]
        public CentroDiLavoro CentriDiLavoro { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd\\-MM\\-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Immettere la data aggiornata")]
        public DateTime DataInizio { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd\\-MM\\-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Immettere la data aggiornata")]
        public DateTime DataFine { get; set; }

    }
}
