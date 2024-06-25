using CadastroPostoVacina.Communication.Responses;

namespace CadastroPostoVacina.Application.UseCases.Vacina.GetAll;
public class GetAllVacinaUseCase
{
    public List<ResponseVacinaJson> Execute()
    {
        var dbContext = new CadastroPostoVacinaDbContext();

        return dbContext.Vacinas
        .Select(p => new ResponseVacinaJson
        {
            Id = p.Id,
            Nome = p.Nome,
            DataValidade = p.DataValidade,
            Fabricante = p.Fabricante,
        }).ToList();

    }
}
