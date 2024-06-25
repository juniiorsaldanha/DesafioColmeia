using CadastroPostoVacina.Application.UseCases.Lote.Register;
using CadastroPostoVacina.Application.UseCases.Vacina.Register;
using CadastroPostoVacina.Communication.Requests;
using CadastroPostoVacina.Communication.Responses;
using CadastroPostoVacina.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPostoVacina.api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LoteController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ReponseRegisteredLoteJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status409Conflict)]
    public IActionResult Register([FromBody] RequestLoteJson request)
    {
        try
        {
            var useCase = new RegisterLoteUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }
        catch(NotFoundException ex)
        {
            return NotFound(new ResponseErrorJson(ex.Message));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorJson(ex.Message));
        }
    }
}
