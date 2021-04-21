using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace malgFunctionApp.Models
{
    class Data
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Estudiante { get; set; }
        [Required]
        public string Temperatura { get; set; }
        [Required]
        public string Fecha { get; set; }
        [Required]
        public string Hora { get; set; }
    }
}
