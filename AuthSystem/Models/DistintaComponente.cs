﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthSystem.Models
{
    public class DistintaComponente
    {
        [Key]
        [Column(TypeName = "nvarchar(128)")]
        public string CodiceComponente { get; set; }
        
        [Column(TypeName = "nvarchar(250)")]
        public string Descrizione { get; set; }

       
    }
}