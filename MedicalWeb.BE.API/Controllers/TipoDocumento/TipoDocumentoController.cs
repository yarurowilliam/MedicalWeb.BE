using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales;
using Microsoft.AspNetCore.Mvc;

namespace MedicalWeb.BE.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TipoDocumentoController : ControllerBase
{
    private readonly ITipoDocumentoBLL _tipodocumentoBLL;

    public TipoDocumentoController(ITipoDocumentoBLL tipodocumentobll)
    {
        _tipodocumentoBLL = tipodocumentobll;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TipoDocumento>>> GetTipoDocumentoAsync()
    {
        var tipodocumentos = await _tipodocumentoBLL.GetTipoDocumentosAsync();
        return Ok(tipodocumentos);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<TipoDocumento>> GetTipoDocumentoByIdAsync(int id)
    {
        var tipodocumento = await _tipodocumentoBLL.GetTipoDocumentoByIdAsync(id);
        if (tipodocumento == null)
        {
            return NotFound();
        }
        return Ok(tipodocumento);
    }

    [HttpPost]
    public async Task<ActionResult<TipoDocumento>> CreateTipoDocumentoAsync(TipoDocumento tipodocumento)
    {
        return await _tipodocumentoBLL.CreateTipoDocumentoAsync(tipodocumento);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TipoDocumento>> UpdateTipoDocumentoAsync(int id, TipoDocumento tipodocumento)
    {
        if (id != tipodocumento.Id)
        {
            return BadRequest();
        }

        var tipodocumentodActualizado = await _tipodocumentoBLL.UpdateTipoDocumentoAsync(tipodocumento);
        return Ok(tipodocumentodActualizado);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<TipoDocumento>> DeleteTipoDocumentoAsync(int id)
    {
        var tipodocumento = await _tipodocumentoBLL.GetTipoDocumentoByIdAsync(id);
        if (tipodocumento == null)
        {
            return NotFound();
        }

        var tipodocumentoEliminado = await _tipodocumentoBLL.DeleteTipoDocumentoAsync(id);
        return Ok(tipodocumentoEliminado);
    }
}
