using System;
using FinancasPessoais.Domain.Entities;
using FinancasPessoais.Domain.Enums;
using FinancasPessoais.Domain.Exceptions;

Console.OutputEncoding = System.Text.Encoding.UTF8;

List<Lancamento> lancamentos = new()
{
    new Entrada("Salário", 5000m, new DateOnly(2026, 10, 5), Categoria.Salario),
    new DespesaFixa("Aluguel", 1500m, new DateOnly(2026, 8, 10), Categoria.Aluguel),
    new DespesaFixa("Internet", 100m, new DateOnly(2026, 10, 15), Categoria.Internet),
    new DespesaVariavel("Mercado", 450m, new DateOnly(2026, 10, 12), Categoria.Alimentacao),
    new DespesaVariavel("Energia", 450m, new DateOnly(2026, 10, 12), Categoria.Moradia),
};

foreach (var lancamento in lancamentos)
{
    string tipo = lancamento is Despesa ? "saída" : "entrada";
    Console.WriteLine($"{lancamento.Descricao} ({lancamento.GetType().Name}, {tipo})");
    Console.WriteLine($"    Setembro/2026:  {lancamento.ValorNoMes(2026, 9):C}");
    Console.WriteLine($"    Outubro/2026:   {lancamento.ValorNoMes(2026, 10):C}");
}

decimal entradas = lancamentos.OfType<Entrada>().Sum(l => l.ValorNoMes(2026, 10));
decimal despesas = lancamentos.OfType<Despesa>().Sum(l => l.ValorNoMes(2026, 10));

Console.WriteLine();
Console.WriteLine($"Entradas de outubro:    {entradas:C}");
Console.WriteLine($"Despesas de outubro:    {despesas:C}");
Console.WriteLine($"Saldo de outubro:       {entradas - despesas:C}");