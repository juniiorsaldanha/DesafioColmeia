using CadastroPostoVacina.Exceptions;
using CadastroPostoVacina.Infrastructure.Entities;

namespace CadastroPostoVacina.Application.UseCases.PostoVacina.Patch;
public class AddLotePostoVacinaByIdUseCase
{
    public string Execute(Guid id, Guid loteId)
    {
        var dbContext = new CadastroPostoVacinaDbContext();

        var entity = dbContext.PostosVacina.Find(id);

        if (entity is null)
            throw new NotFoundException("Posto não encontrado.");

        var lote = dbContext.Lote.Find(loteId);

        if (lote is null)
            throw new NotFoundException("Lote não encontrado.");

        if (lote.Quantidade == 0)
            throw new Exception("O Lote está sem vacinas disponiveis");

        lote.PostoVacinaId = entity.Id;

        dbContext.SaveChanges();

        return $"Lote {loteId} cadastrado com sucesso";
    }
}
