using FinancasPessoais.Domain.Enums;
using FinancasPessoais.Domain.Exceptions;

namespace FinancasPessoais.Domain.Entities;

public class DespesaFixa : Lancamento
{
    public DespesaFixa(string descricao, decimal valor, DateOnly data, Categoria categoria)
        : base(descricao, valor, data, categoria)
    {
    }

    public override decimal ValorNoMes(int ano, int mes)
    {
        var inicio = new DateOnly(Data.Year, Data.Month, 1);
        var mesConsultado = new DateOnly(ano, mes, 1);

        return mesConsultado >= inicio ? Valor : 0m;
    }
}