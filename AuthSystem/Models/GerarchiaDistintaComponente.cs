using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Models
{
    public class GerarchiaDistintaComponente
    {
       
        [Column(TypeName = "nvarchar(128)")]
        public string CodiceComponente { get; set; }
        [ForeignKey("CodiceComponente ")]
        public DistintaComponente DistintaComponenti { get; set; }
        [Key]
        [Column(TypeName = "nvarchar(128)")]
        public string CodiceComponentePadre { get; set; }
        public string DescrizioneComponentePadre { get; }

    }
}
