using FinancasPessoais.Domain.Entities;
using FinancasPessoais.Domain.Enums;
using FinancasPessoais.Domain.Exceptions;

namespace FinancasPessoais.Tests;

public class DespesaParceladaTests
{
    [Theory]
    [InlineData(2026, 9, 0)]
    [InlineData(2026, 10, 400)]
    [InlineData(2026, 11, 400)]
    [InlineData(2026, 12, 400)]
    [InlineData(2027, 1, 0)]

    public void ValorNoMes_RespeitaOPeriodoDasParcelas(int ano, int mes, int esperado)
    {
        var compra = new DespesaParcelada("Geladeira", 1200m, new DateOnly(2026, 10, 20), Categoria.Moradia, 3);

        Assert.Equal((decimal)esperado, compra.ValorNoMes(ano, mes));
    }

    [Fact]
    public void  UltimaParcela_AbsorveADiferencaDeCentavos()
    {
        var compra = new DespesaParcelada("Compra", 1000m, new DateOnly(2026, 10, 1), Categoria.Outros, 3);

        Assert.Equal(333.33m, compra.ValorNoMes(2026, 10));
        Assert.Equal(333.33m, compra.ValorNoMes(2026, 11));
        Assert.Equal(333.34m, compra.ValorNoMes(2026, 12));
    }

    [Fact]
    public void SomaDasParcelas_DeveSerIgualAoValorTotal()
    {
        var compra = new DespesaParcelada("Compra", 1000m, new DateOnly(2026, 10, 1), Categoria.Outros, 3);

        decimal soma = Enumerable.Range(0, 3).Sum(i => compra.ValorNoMes(2026, 10 + i));

        Assert.Equal(1000m, soma);
    }

    [Fact]
    public void ValorNoMes_AtravessaAViradaDoAno()
    {
        var compra = new DespesaParcelada("Notebook", 2000m, new DateOnly(2026, 11, 5), Categoria.Outros, 4);

        Assert.Equal(500m, compra.ValorNoMes(2026, 12));
        Assert.Equal(500m, compra.ValorNoMes(2027, 2));
        Assert.Equal(0m, compra.ValorNoMes(2027, 3));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(0)]
    [InlineData(-3)]
    public void Criar_ComMenosDeDuasParcelas_DeveLancarDominioException(int parcelas)
    {
        Assert.Throws<DominioException>(() =>
            new DespesaParcelada("Compra", 1000m, new DateOnly(2026, 10, 1), Categoria.Outros, parcelas));
    }
}