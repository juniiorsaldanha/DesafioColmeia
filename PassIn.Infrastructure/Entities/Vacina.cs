using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroPostoVacina.Infrastructure.Entities;
public class Vacina
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Fabricante { get; set; } = string.Empty;
    public DateTime DataValidade { get; set; }
}