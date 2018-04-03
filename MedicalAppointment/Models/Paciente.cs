using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.ComponentModel.DataAnnotations;

namespace MedicalAppointment.Models
{
    public class Paciente
    {
        [Key]
        [Required]
        public int Id { set; get; }
        [Required]
        public string Nombre { set; get; }
        [Required]
        public int Edad { set; get; }
        [Required]
        public string Sexo { set; get; }
    }
}