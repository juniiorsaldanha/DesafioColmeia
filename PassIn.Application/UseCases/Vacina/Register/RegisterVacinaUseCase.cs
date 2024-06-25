using CadastroPostoVacina.Communication.Requests;
using CadastroPostoVacina.Communication.Responses;
using CadastroPostoVacina.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroPostoVacina.Application.UseCases.Vacina.Register;
public class RegisterVacinaUseCase
{
    public ResponseRegisteredVacinaJson Execute(RequestVacinaJson request)
    {
        var dbContext = new CadastroPostoVacinaDbContext();

        if(request.DataValidade <= DateTime.Now)
            throw new CadastroPostoVacinaException("A data de validade deve ser uma data futura.");

        var entity = new Infrastructure.Entities.Vacina
        {
            Nome = request.Nome,
            Fabricante = request.Fabricante,
            DataValidade = request.DataValidade,
        };

        dbContext.Vacinas.Add(entity);
        dbContext.SaveChanges();

        return new ResponseRegisteredVacinaJson
        {
            Id = entity.Id
        };
    }
}
