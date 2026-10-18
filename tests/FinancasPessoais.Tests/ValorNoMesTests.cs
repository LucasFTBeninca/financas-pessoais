using FinancasPessoais.Domain.Entities;
using FinancasPessoais.Domain.Enums;

namespace FinancasPessoais.Tests;

public class ValorNoMesTests
{
    [Theory]
    [InlineData(2026, 10, 5000)]
    [InlineData(2026, 9, 0)]
    [InlineData(2027, 10, 0)]
    public void Entrada_SoPesaNoMesDaData(int ano, int mes, int esperado)
    {
        var entrada = new Entrada("Salário", 5000m, new DateOnly(2026, 10, 5), Categoria.Salario);

        var resultado = entrada.ValorNoMes(ano, mes);

        Assert.Equal((decimal)esperado, resultado);
    }

    [Theory]
    [InlineData(2026, 7, 0)]
    [InlineData(2026, 8, 1500)]
    [InlineData(2026, 9, 1500)]
    [InlineData(2027, 3, 1500)]
    public void DespesaFixa_PesaDoMesDeInicioEmDiante(int ano, int mes, int esperado)
    {
        var aluguel = new DespesaFixa("Aluguel", 1500m, new DateOnly(2026, 8, 10), Categoria.Moradia);

        var resultado = aluguel.ValorNoMes(ano, mes);

        Assert.Equal((decimal)esperado, resultado);
    }

    [Fact]
    public void DespesaVariavel_SoPesaNoMesDaData()
    {
        var mercado = new DespesaVariavel("Mercado", 450m, new DateOnly(2026, 10, 12), Categoria.Alimentacao);

        Assert.Equal(450m, mercado.ValorNoMes(2026, 10));
        Assert.Equal(0m, mercado.ValorNoMes(2026, 11));
    }
}