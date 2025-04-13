using MedicalWeb.BE.Repositorio;
using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using MedicalWeb.BE.Transversales.Entidades.MedicamentosRecetados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWeb.BE.Servicio;

public class MedicamentosRecetadosBLL : IMedicamentosRecetadosBLL
{
    private readonly IMedicamentosRecetadosDAL _medicamentosRecetadosDAL;


    public MedicamentosRecetadosBLL(IMedicamentosRecetadosDAL medicamentosRecetadosDAL)
    {
        _medicamentosRecetadosDAL = medicamentosRecetadosDAL;
    }
    public async Task<MedicoPacienteDTO> ObtenerInfoMedicoYPacienteAsync(string documentoMedico, string documentoPaciente)
    {
        return await _medicamentosRecetadosDAL.ObtenerInfoMedicoYPacienteAsync(documentoMedico, documentoPaciente);
    }

    public async Task InsertarRecetaConMedicamentosAsync(RecetaCompletaDTO recetaDTO)
    {
        await _medicamentosRecetadosDAL.InsertarRecetaConMedicamentosAsync(recetaDTO);
    }
}
