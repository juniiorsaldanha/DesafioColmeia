using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroPostoVacina.Infrastructure.Entities;

public class PostoVacina
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Endereço { get; set; } = string.Empty;
    public ICollection<Lote> Lotes { get; set; } = new List<Lote>();
}

