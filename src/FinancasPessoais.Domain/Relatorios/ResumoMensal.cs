namespace FinancasPessoais.Domain.Relatorios;

public class ResumoMensal
{
    public int Ano { get; }
    public int Mes { get; }
    public decimal TotalEntradas { get; }
    public decimal TotalDespesas { get; }
    public decimal Saldo => TotalEntradas - TotalDespesas;

    public ResumoMensal(int ano, int mes, decimal totalEntradas, decimal totalDespesas)
    {
        Ano = ano;
        Mes = mes;
        TotalEntradas = totalEntradas;
        TotalDespesas = totalDespesas;
    }
}