using CadastroPostoVacina.Application.UseCases.PostoVacina.Delete;
using CadastroPostoVacina.Application.UseCases.PostoVacina.GetAll;
using CadastroPostoVacina.Application.UseCases.PostoVacina.GetById;
using CadastroPostoVacina.Application.UseCases.PostoVacina.Patch;
using CadastroPostoVacina.Application.UseCases.PostoVacina.Register;
using CadastroPostoVacina.Communication.Requests;
using CadastroPostoVacina.Communication.Responses;
using CadastroPostoVacina.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPostoVacina.api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PostoVacinaController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredPostoVacinaJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status409Conflict)]
    public IActionResult Register([FromBody] RequestPostoVacinaJson request)
    {
        try
        {
            var useCase = new RegisterPostoVacinaUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }
        catch (ConflictException ex)
        {
            return Conflict(new ResponseErrorJson(ex.Message));
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorJson("Unknown error"));
        }
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponsePostoVacinaJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute] Guid id)
    {

        try
        {
            var useCase = new GetPostoVacinaByIdUseCase();

            var response = useCase.Execute(id);

            return Ok(response);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new ResponseErrorJson(ex.Message));
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorJson("Unknown error"));
        }


    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]

    public IActionResult DeleteById([FromRoute] Guid id)
    {
        try
        {
            var useCase = new DeletePostoVacinaByIdUseCase();

            var response = useCase.Execute(id);

            return Ok(response);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new ResponseErrorJson(ex.Message));
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorJson("Unknown Error"));
        }
    }


    [HttpGet]
    [ProducesResponseType(typeof(ResponsePostoVacinaJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult GetAll()
    {

        try
        {
            var useCase = new GetAllPostoVacinaUseCase();

            var response = useCase.Execute();

            return Ok(response);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorJson("Unknown error"));
        }
    }

    [HttpPatch]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]

    public IActionResult AddLote([FromBody] RequestAddLotePostoVacinaJson request)
    {
        try
        {
            var useCase = new AddLotePostoVacinaByIdUseCase();

            var response = useCase.Execute(request.Id, request.LoteId);

            return Ok(response);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new ResponseErrorJson(ex.Message));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorJson(ex.Message));
        }
    }

}
