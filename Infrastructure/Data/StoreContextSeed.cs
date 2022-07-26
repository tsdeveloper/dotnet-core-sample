using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Bogus;
using Bogus.Extensions.Brazil;
using Core.Entities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedClientesAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                if (!context.DbSet<Cliente>().Any())
                {
                    Randomizer.Seed = new Random(1);
                    var clientIds= 1;
                    var clientFaker = new Faker<Cliente>()
                        .RuleFor(p => p.Cpf, p => p.Person.Cpf(false))
                        .RuleFor(p => p.Nome, p => p.Person.FirstName)
                        .RuleFor(p => p.Celular, p => p.Person.Phone)

                        .RuleFor(p => p.UF, p => p.Random.CollectionItem( new List<string>
                        {
                            "SP",
                            "RJ",
                            "BSB",
                            "SC",
                            "BA",
                            "MG",
                            "PE",
                        }))
                        .Generate(100);

                  
                    context.DbSet<Cliente>().AddRange(clientFaker);
                   
                    await context.SaveChangesAsync();
                }

                
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
        public static async Task SeedFinanciamentoAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {


                if (!context.DbSet<Financiamento>().Any())
                {
                    Randomizer.Seed = new Random(4675312);

                    var financiamentoFaker = new Faker<Financiamento>()
                        .RuleFor(p => p.Cpf, p => p.Person.Cpf())
                        .RuleFor(p => p.Tipo, p => p.Random.CollectionItem( new List<string>
                        {
                            "Finanamento de Veículos",
                            "Finanamento Imobiliários",
                            "Finanamento Finame",
                            "Finanamento Rural",
                        }))
                        .RuleFor(p => p.DataUltimoVencimento, p => p.Date.Between(DateTime.Now.AddYears(-3), DateTime.Now))
                        .RuleFor(p => p.ValorTotal, p => p.Random.Decimal(10, 100))
                        .Generate(200);
                    
                    int index = 1;
                    
                    while (financiamentoFaker.Exists(x => x.ClienteId == 0))
                    {
                        var listCliente = context.DbSet<Cliente>().Skip(index++).Take(4).ToList();

                        foreach (var cliente in listCliente)
                        {
                            foreach (var financiamento in financiamentoFaker.Where(x => x.ClienteId == 0).Take(1))
                            {
                                financiamento.ClienteId = cliente.Id;
                            }
                        }
                    }
                   
                    context.DbSet<Financiamento>().AddRange(financiamentoFaker);
                    await context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
        public static async Task SeedParcelasAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.DbSet<Parcela>().Any())
                {
                    Randomizer.Seed = new Random(4675312);
                    
                    var parcelasFaker = new Faker<Parcela>()
                        
                        .RuleFor(p => p.NumParcelas, p => p.Random.Number(1, 4).ToString().PadLeft(9, '0'))
                        .RuleFor(p => p.DataPagamento, p => p.Date.Between(DateTime.Now.AddYears(-3), DateTime.Now))
                        .RuleFor(p => p.ValorParcela, p => p.Random.Decimal(10, 100))
                        .Generate(100);
                    int index = 1;
                    while (parcelasFaker.Exists(x => x.FinanciamentoId == 0))
                    {
                        var listFinanciamento = context.DbSet<Financiamento>().Skip(index++).Take(4).ToList();

                        foreach (var financiamento in listFinanciamento)
                        {
                            foreach (var parcela in parcelasFaker.Where(x => x.FinanciamentoId == 0).Take(4))
                            {
                                parcela.FinanciamentoId = financiamento.Id;
                            }
                        }
                    }
                    

                  
                    context.DbSet<Parcela>().AddRange(parcelasFaker);
                   
                    await context.SaveChangesAsync();
                }

                
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}