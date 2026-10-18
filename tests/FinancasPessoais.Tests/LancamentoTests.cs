using FinancasPessoais.Domain.Entities;
using FinancasPessoais.Domain.Enums;
using FinancasPessoais.Domain.Exceptions;

namespace FinancasPessoais.Tests;

public class LancamentoTestes
{
    [Fact]
    public void Criar_ComValorZero_DeveLancarDominioException()
    {
        var excecao = Assert.Throws<DominioException>(() =>
            new Entrada("Salário", 0m, new DateOnly(2026, 10, 5), Categoria.Salario));

        Assert.Equal("O valor deve ser maior que zero!", excecao.Message);
    }

    [Fact]
    public void Criar_ComDescricaoVazia_DeveLancarDominioException()
    {
        Assert.Throws<DominioException>(() => 
            new DespesaFixa("   ", 100m, new DateOnly(2026, 10, 5), Categoria.Moradia));
    }
}