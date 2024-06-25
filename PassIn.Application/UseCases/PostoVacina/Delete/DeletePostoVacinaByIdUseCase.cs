using CadastroPostoVacina.Communication.Responses;
using CadastroPostoVacina.Exceptions;

namespace CadastroPostoVacina.Application.UseCases.PostoVacina.Delete;
public class DeletePostoVacinaByIdUseCase
{
    public string Execute(Guid id)
    {
        var dbContext = new CadastroPostoVacinaDbContext();

        var entity = dbContext.PostosVacina.Find(id);

        if (entity is null)
            throw new NotFoundException("Posto não encontrado.");

        var lote = dbContext.Lote.FirstOrDefault(x => x.PostoVacinaId == id);

        if(lote is not null)
            throw new Exception("Não é possível deletar um posto com vacinas associadas");

        dbContext.Remove(entity);
        dbContext.SaveChanges();

        return $"Posto {entity.Nome} deletado com sucesso";
    }
}
