using CadastroPostoVacina.Communication.Requests;
using CadastroPostoVacina.Communication.Responses;
using CadastroPostoVacina.Exceptions;
using CadastroPostoVacina.Infrastructure;

namespace CadastroPostoVacina.Application.UseCases.PostoVacina.Register;
public class RegisterPostoVacinaUseCase
{
    public ResponseRegisteredPostoVacinaJson Execute(RequestPostoVacinaJson request)
    {
        var dbContext = new CadastroPostoVacinaDbContext();

        if(dbContext.PostosVacina.Any(p => p.Nome == request.Nome))
            throw new ConflictException("Já existe um posto de vacinação com este nome.");

        var entity = new Infrastructure.Entities.PostoVacina
        {
            Endereço = request.Endereço,
            Nome = request.Nome,
        };

        dbContext.PostosVacina.Add(entity);
        dbContext.SaveChanges();

        return new ResponseRegisteredPostoVacinaJson
        {
            Id = entity.Id
        };
    }
}
