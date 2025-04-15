using MedicalWeb.BE.Repositorio;
using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWeb.BE.Servicio;

public class IncapacidadBLL: IIncapacidadBLL
{
    private readonly IIncapacidadDAL _IncapacidadDAL;


    public IncapacidadBLL(IIncapacidadDAL incapacidadDAL)
    {
        _IncapacidadDAL = incapacidadDAL;
    }

    public async Task InsertarIncapacidadAsync(IncapacidadDTO incapacidadDTO)
    {
        await _IncapacidadDAL.InsertarIncapacidadAsync(incapacidadDTO  );
    }

    public async Task<MedicoPacienteDTO> ObtenerInfoMedicoYPacienteAsync(string documentoMedico, string documentoPaciente)
    {
        return await _IncapacidadDAL.ObtenerInfoMedicoYPacienteAsync(documentoMedico, documentoPaciente);
    }
}
