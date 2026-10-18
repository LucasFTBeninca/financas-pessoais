using FinancasPessoais.Domain.Entities;
using FinancasPessoais.Domain.Enums;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var extrato = new Extrato();

extrato.Adicionar(new Entrada("Salário", 5000m, new DateOnly(2026, 10, 5), Categoria.Salario));
extrato.Adicionar(new DespesaFixa("Aluguel", 1500m, new DateOnly(2026, 8, 10), Categoria.Moradia));
extrato.Adicionar(new DespesaFixa("Internet", 100m, new DateOnly(2026, 10, 15), Categoria.Moradia));
extrato.Adicionar(new DespesaVariavel("Mercado", 450m, new DateOnly(2026, 10, 12), Categoria.Alimentacao));
extrato.Adicionar(new DespesaVariavel("Energia", 450m, new DateOnly(2026, 10, 12), Categoria.Moradia));
extrato.Adicionar(new DespesaParcelada("Notebook", 3000m, new DateOnly(2026, 10, 20), Categoria.Outros, 10));

foreach (var mes in new[] { 9, 10, 11 })
{
    var resumo = extrato.GerarResumo(2026, mes);

    Console.WriteLine($"Resumo de {resumo.Mes:00}/{resumo.Ano}");
    Console.WriteLine($"  Entradas: {resumo.TotalEntradas:C}");
    Console.WriteLine($"  Despesas: {resumo.TotalDespesas:C}");
    Console.WriteLine($"  Saldo:    {resumo.Saldo:C}");
    Console.WriteLine();
}