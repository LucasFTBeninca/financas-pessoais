using FinancasPessoais.Domain.Exceptions;
using FinancasPessoais.Domain.Relatorios;

namespace FinancasPessoais.Domain.Entities;

public class Extrato
{
    private readonly List<Lancamento> _lancamentos = new();

    public IReadOnlyList<Lancamento> Lancamentos => _lancamentos;

    public void Adicionar(Lancamento lancamento)
    {
        ArgumentNullException.ThrowIfNull(lancamento);
        _lancamentos.Add(lancamento);
    }

    public ResumoMensal GerarResumo(int ano, int mes)
    {
        decimal entradas = _lancamentos
        .OfType<Entrada>()
        .Sum(lancamento => lancamento.ValorNoMes(ano, mes));

        decimal despesas = _lancamentos
        .OfType<Despesa>()
        .Sum(lancamento => lancamento.ValorNoMes(ano, mes));

        return new ResumoMensal(ano, mes, entradas, despesas);
    }
}