using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MedicalAppointment.Models;

namespace MedicalAppointment.DAL
{
    public interface ITipoCitaRepository : IDisposable
    {
        List<TipoCita> GetTipoCitas();

        TipoCita GetTipoCitaByID(int? tipoCitaId);
    }
}