using FinancasPessoais.Domain.Enums;
using FinancasPessoais.Domain.Exceptions;

namespace FinancasPessoais.Domain.Exceptions;

public abstract class Lancamento
{
    public Guid Id { get; private set; }
    public string Descricao { get; private set; }
    public decimal Valor { get; private set; }
    public DateOnly Data { get; private set; }
    public Categoria Categoria { get; private set; }

protected Lancamento(string descricao, decimal valor, DateOnly data, Categoria categoria)
{
    if (string.IsNullOrWhiteSpace(descricao))
        throw new DominioException("A descrição é obrigatória.");

    if (valor <= 0)
        throw new DominioException("O valor deve ser maior que zero!");

        Id = Guid.NewGuid();
        Descricao = descricao.Trim();
        Valor = valor;
        Data = data;
        Categoria = categoria;
}

public abstract decimal ValorNoMes(int ano, int mes);
}