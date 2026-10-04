using FinancasPessoais.Domain.Enums;

namespace FinancasPessoais.Domain.Entities;

public class DespesaVariavel : Despesa
{
    public DespesaVariavel(string descricao, decimal valor, DateOnly data, Categoria categoria)
        : base(descricao, valor, data, categoria)
    {    
    }

    public override decimal ValorNoMes(int ano, int mes)
    {
        return OcorreNoMes(ano, mes) ? Valor : 0m;
    }
}