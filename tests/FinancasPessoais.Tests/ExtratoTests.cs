using FinancasPessoais.Domain.Entities;
using FinancasPessoais.Domain.Enums;

namespace FinancasPessoais.Tests;

public class ExtratoTests
{
    [Fact]
    public void GerarResumo_DeveSepararEntradasDeDespesasECalcularSaldo()
    {
        var extrato = new Extrato();
        extrato.Adicionar(new Entrada("Salário", 5000m, new DateOnly(2026, 10, 5), Categoria.Salario));
        extrato.Adicionar(new DespesaFixa("Aluguel", 1500m, new DateOnly(2026, 8, 10), Categoria.Moradia));
        extrato.Adicionar(new DespesaVariavel("Mercado", 450m, new DateOnly(2026, 10, 12), Categoria.Alimentacao));

        var resumo = extrato.GerarResumo(2026, 10);

        Assert.Equal(5000m, resumo.TotalEntradas);
        Assert.Equal(1950m, resumo.TotalDespesas);
        Assert.Equal(3050m, resumo.Saldo);
    }

    [Fact]
    public void GerarResumo_SemLancamentos_DeveRetornarZeros()
    {
        var extrato = new Extrato();

        var resumo = extrato.GerarResumo(2026, 10);

        Assert.Equal(0m, resumo.TotalEntradas);
        Assert.Equal(0m, resumo.TotalDespesas);
        Assert.Equal(0m, resumo.Saldo);
    }

    [Fact]
    public void Adicionar_ComNulo_DeveLancarArgumentNullException()
    {
        var extrato = new Extrato();

        Assert.Throws<ArgumentNullException>(() => extrato.Adicionar(null!));
    }
}