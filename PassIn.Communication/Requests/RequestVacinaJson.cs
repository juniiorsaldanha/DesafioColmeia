using CadastroPostoVacina.Infrastructure.Entities;

namespace CadastroPostoVacina.Communication.Requests;
public class RequestVacinaJson
{
    public string Nome { get; set; } = string.Empty;
    public string Fabricante { get; set; } = string.Empty;
    public DateTime DataValidade { get; set; }
}
