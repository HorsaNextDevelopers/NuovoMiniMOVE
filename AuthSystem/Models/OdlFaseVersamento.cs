using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Models
{
    public class OdlFaseVersamento
    {
        [Key]
        [Column(TypeName = "nvarchar(128)")]
        public string IdVersamento { get; set; }

        public string CodiceArticolo { get; set; }
        [ForeignKey("CodiceArticolo ")]
        public Articolo Articoli { get; set; }
        public string CodiceOdl { get; set; }
        [ForeignKey("CodiceOdl ")]
        public OdlFase OdlFasi { get; set; }
        public int FaseODL { get; set; }

        public string CodiceMacchinaFisica { get; set; }
        [ForeignKey("CodiceMacchinaFisica ")]
        [DisplayName("CodiceMacchinaFisica")]
        public MacchinaFisica MacchinaFisiche { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd\\-MM\\-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Immettere la data aggiornata")]
        [DisplayName("Data inizio")]
        public DateTime DataInizio { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd\\-MM\\-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Immettere la data aggiornata")]
        [DisplayName("Data fine")]
        public DateTime DataFine { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:hh\\-mm\\-ss}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Immettere la data aggiornata")]
        [DisplayName("Data fine")]
        public DateTime TempoLavoroNetto { get; set; }

        public int PezziBuoni { get; set; }
        public int PezziScartati { get; set; }

    }
}
