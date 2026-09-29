namespace DimDim.Web.Models;

public class Transacao
{
    public int Id { get; set; }

    public string Descricao { get; set; } = string.Empty;

    public decimal Valor { get; set; }

    public string Tipo { get; set; } = string.Empty;

    public DateTime Data { get; set; }

    public int ClienteId { get; set; }

    public Cliente? Cliente { get; set; }
}