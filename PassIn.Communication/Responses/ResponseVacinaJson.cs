using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroPostoVacina.Communication.Responses;
public class ResponseVacinaJson
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Fabricante { get; set; } = string.Empty;
    public DateTime DataValidade { get; set; }
}
