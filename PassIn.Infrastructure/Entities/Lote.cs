namespace CadastroPostoVacina.Infrastructure.Entities;
public class Lote
{
    public Guid Id { get; set; }
    public Guid VacinaId { get; set; }
    public int Quantidade { get; set; }
    public Guid? PostoVacinaId { get; set; }
}
