using FinancasPessoais.Domain.Enums;
using FinancasPessoais.Domain.Exceptions;

namespace FinancasPessoais.Domain.Entities;

public class Entrada : Lancamento
{
    public Entrada(string descricao, decimal valor, DateOnly data, Categoria categoria)
        : base(descricao, valor, data, categoria)
    {
        
    }

    public override decimal ValorNoMes(int ano, int mes)
    {
        return OcorreNoMes(ano, mes) ? Valor : 0m;
    }
}