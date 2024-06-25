using CadastroPostoVacina.Application.UseCases.Vacina.GetAll;
using CadastroPostoVacina.Application.UseCases.Vacina.Register;
using CadastroPostoVacina.Communication.Requests;
using CadastroPostoVacina.Communication.Responses;
using CadastroPostoVacina.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPostoVacina.api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class VacinaController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredVacinaJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestVacinaJson request)
    {
        try
        {
            var useCase = new RegisterVacinaUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }
        catch (CadastroPostoVacinaException ex)
        {
            return BadRequest(new ResponseErrorJson(ex.Message));
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorJson("Erro Desconhecido"));
        }
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseVacinaJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult GetAll()
    {

        try
        {
            var useCase = new GetAllVacinaUseCase();

            var response = useCase.Execute();

            return Ok(response);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorJson("Unknown error"));
        }


    }

}