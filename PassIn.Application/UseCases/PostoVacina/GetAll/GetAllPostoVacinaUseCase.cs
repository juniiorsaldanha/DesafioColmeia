using CadastroPostoVacina.Communication.Responses;
using CadastroPostoVacina.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CadastroPostoVacina.Application.UseCases.PostoVacina.GetAll;
public class GetAllPostoVacinaUseCase
{
    public List<ResponsePostoVacinaJson> Execute()
    {
        var dbContext = new CadastroPostoVacinaDbContext();

        return dbContext.PostosVacina
        .Select(p => new ResponsePostoVacinaJson
        {
            Id = p.Id,
            Nome = p.Nome,
            Endereço = p.Endereço,
        }).ToList();

    }
}
