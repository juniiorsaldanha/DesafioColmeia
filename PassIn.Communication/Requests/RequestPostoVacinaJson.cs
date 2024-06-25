using CadastroPostoVacina.Infrastructure.Entities;

namespace CadastroPostoVacina.Communication.Requests;
public class RequestPostoVacinaJson
{  
    public string Nome { get; set; } = string.Empty;
    public string Endereço { get; set; } = string.Empty;
}
