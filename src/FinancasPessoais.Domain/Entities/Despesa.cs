using FinancasPessoais.Domain.Enums;
using FinancasPessoais.Domain.Exceptions;

namespace FinancasPessoais.Domain.Entities;

public abstract class Despesa : Lancamento
{
    protected Despesa(string descricao, decimal valor, DateOnly data, Categoria categoria)
        : base(descricao, valor, data, categoria)
    {
    }
}