using MedicalWeb.BE.Servicio;
using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace MedicalWeb.BE.API.Controllers.HistoriaClinica
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoriaClinicaController : ControllerBase
    {
        private readonly IHistoriaClinicaBLL _historiaClinicaBLL;
        private readonly IMedicoBLL _medicoBLL;
        private readonly IPacientesBLL _pacientesBLL;
        public HistoriaClinicaController(IHistoriaClinicaBLL historiaClinicaBLL, IMedicoBLL medicoBLL, IPacientesBLL pacientesBLL)
        {
            _historiaClinicaBLL=historiaClinicaBLL;
            _medicoBLL=medicoBLL;
            _pacientesBLL=pacientesBLL;
        }

        [HttpGet]
        public async Task<IEnumerable<HistoriaClinicaDTO>> GetAllAsync()
        {
            return await _historiaClinicaBLL.GetAllAsync();
        }

        [HttpGet("medico/{documentoMedico}")]
        public async Task<IActionResult> GetMedicoByDocumento(string documentoMedico)
        {
            var medico = await _medicoBLL.GetByIdAsync(documentoMedico);

            if (medico == null)
            {
                return NotFound("Médico no encontrado"); 
            }

            return Ok(new
            {
                nombre = medico.PrimerNombre,
                segundoNombre = medico.SegundoNombre,
                apellido = medico.PrimerApellido,
                segundoApellido = medico.SegundoApellido,
                genero = medico.Genero
            });
        }

        [HttpGet("paciente/{documentoPaciente}")]
        public async Task<IActionResult> GetPacienteByDocumento(string documentoPaciente)
        {
            var paciente = await _pacientesBLL.GetByIdAsync(documentoPaciente);
            if (paciente == null)
            {
                return NotFound("Paciente no encontrado"); 
            }
            return Ok(new
            {
                nombre = paciente.PrimerNombre,
                segundoNombre = paciente.SegundoNombre,
                apellido = paciente.PrimerApellido,
                segundoApellido = paciente.SegundoApellido,
                genero = paciente.Genero,
                telefono = paciente.Telefono
            });
        }

        [HttpPost]
        public async Task<HistoriaClinicaDTO> InsertAsync(HistoriaClinicaDTO historiaClinicaDTO)
        {
            return await _historiaClinicaBLL.InsertAsync(historiaClinicaDTO);
        }

        [HttpPut]
        public async Task<HistoriaClinicaDTO> UpdateAsync(HistoriaClinicaDTO historiaClinicaDTO)
        {
            return await _historiaClinicaBLL.UpdateAsync(historiaClinicaDTO);
        }

        [HttpDelete("{numeroDocumento}")]
        public async Task DeleteAsync(string numeroDocumento)
        {
            await _historiaClinicaBLL.DeleteAsync(numeroDocumento);
        }


    }
}
