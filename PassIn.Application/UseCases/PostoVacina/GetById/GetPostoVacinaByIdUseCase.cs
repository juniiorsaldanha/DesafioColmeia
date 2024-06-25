using CadastroPostoVacina.Communication.Responses;
using CadastroPostoVacina.Exceptions;

namespace CadastroPostoVacina.Application.UseCases.PostoVacina.GetById;
public class GetPostoVacinaByIdUseCase
{
    public ResponsePostoVacinaJson Execute(Guid id)
    {
        var dbContext = new CadastroPostoVacinaDbContext();

        var entity = dbContext.PostosVacina.Find(id);
        if (entity is null)
            throw new NotFoundException("Posto não encontrado");

        return new ResponsePostoVacinaJson
        {
            Id = entity.Id,
            Nome = entity.Nome,
            Endereço = entity.Endereço
        };
    }
}
