using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace AuthSystem.Models
    
{
    public class Articolo
    {
        
        [Key]
        [Column(TypeName = "nvarchar(128)")]
        public string CodiceArticolo { get; set; }
        
        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Immettere la descrizione dell'articolo")]
        [DisplayName("Descrizione articolo")]
        public string Descrizione { get; set; }
        
    }
}
