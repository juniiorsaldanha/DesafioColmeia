using CadastroPostoVacina.Communication.Requests;
using CadastroPostoVacina.Communication.Responses;
using CadastroPostoVacina.Exceptions;

namespace CadastroPostoVacina.Application.UseCases.Lote.Register;
public class RegisterLoteUseCase
{
    public ReponseRegisteredLoteJson Execute(RequestLoteJson request)
    {
        var dbContext = new CadastroPostoVacinaDbContext();

        if (!dbContext.Vacinas.Any(vac => vac.Id == request.VacinaId))
            throw new NotFoundException("Vacina não encontrada");

        var entity = new Infrastructure.Entities.Lote
        {
            Quantidade = request.Quantidade,
            VacinaId = request.VacinaId,
        };

        dbContext.Lote.Add(entity);
        dbContext.SaveChanges();

        return new ReponseRegisteredLoteJson
        {
            Id = entity.Id
        };
    }
}
