using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointment.Models
{
    public class Cita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        //[ForeignKey("Paciente")]
        public int PacienteId { set; get; }
        public DateTime Fecha { set; get; }
        //[ForeignKey("TipoCita")]
        public int TipoCitaId { set; get; }
    }
}