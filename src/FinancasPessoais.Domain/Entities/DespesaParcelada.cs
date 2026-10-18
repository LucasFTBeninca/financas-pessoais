using FinancasPessoais.Domain.Enums;
using FinancasPessoais.Domain.Exceptions;

namespace FinancasPessoais.Domain.Entities;

public class DespesaParcelada : Despesa
{
    public int NumeroParcelas { get; }

    public DespesaParcelada(
        string descricao,
        decimal valorTotal,
        DateOnly dataPrimeiraParcela,
        Categoria categoria,
        int numeroParcelas)
        : base(descricao, valorTotal, dataPrimeiraParcela, categoria)
    {
        if (numeroParcelas < 2)
            throw new DominioException("O número de parcelas deve ser no mínimo 2.");

        NumeroParcelas = numeroParcelas;
    }
    
    public decimal ValorDaParcela(int numeroDaParcela)
    {
        if (numeroDaParcela < 1 || numeroDaParcela > NumeroParcelas)
            throw new DominioException("Número de parcela inválido.");

        decimal parcelaBase = Math.Round(Valor / NumeroParcelas, 2, MidpointRounding.AwayFromZero);

        if (numeroDaParcela < NumeroParcelas)
            return parcelaBase;

        return Valor - parcelaBase * (NumeroParcelas - 1);
    }

    public override decimal ValorNoMes(int ano, int mes)
    {
        int deslocamento = (ano - Data.Year) * 12 + (mes - Data.Month);

        if (deslocamento < 0 || deslocamento >= NumeroParcelas)
            return 0m;

        return ValorDaParcela(deslocamento + 1);
    }
}