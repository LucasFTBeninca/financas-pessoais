using System;
using FinancasPessoais.Domain.Entities;
using FinancasPessoais.Domain.Enums;
using FinancasPessoais.Domain.Exceptions;

Console.OutputEncoding = System.Text.Encoding.UTF8;

List<Lancamento> lancamentos = new()
{
    new Entrada("Salário", 5000m, new DateOnly(2026, 10, 5), Categoria.Salario),
    new DespesaFixa("Aluguel", 1500m, new DateOnly(2026, 8, 10), Categoria.Aluguel),
    new DespesaFixa("Internet", 100m, new DateOnly(2026, 10, 15), Categoria.Internet)
};

foreach (var lancamento in lancamentos)
{
    Console.WriteLine($"{lancamento.Descricao} ({lancamento.GetType().Name})");
    Console.WriteLine($"    Setembro/2026:  {lancamento.ValorNoMes(2026, 9):C}");
    Console.WriteLine($"    Outubro/2026:   {lancamento.ValorNoMes(2026, 10):C}");
}

var teste = new Lancamento("X", 10m, new DateOnly(2026, 10, 1), Categoria.Outros);