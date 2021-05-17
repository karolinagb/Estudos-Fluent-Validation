using EstudosFluentValidation.Models;
using EstudosFluentValidation.Models.Enums;
using EstudosFluentValidation.Models.Validacao;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EstudosFluentValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            ItemVenda item1 = new ItemVenda()
            {
                Descricao = "Cabo USB 2.5m",
                Preco = 35,
                Quantidade = 1
            };

            ItemVenda item2 = new ItemVenda()
            {
                Descricao = "",
                Preco = 0,
                Quantidade = 0
            };

            Venda venda = new Venda();
            venda.Data = DateTime.Today;
            venda.Tipo = TipoVenda.Brinde;
            venda.Total = 0;
            venda.Itens = new List<ItemVenda>(new[] { item1});

            //Instância da classe de validação
            VendaValidator vendaValidator = new VendaValidator();

            //Método Validate retorna os resultados da validação e os mesmos são representados pela classe ValidationResult
            //ValidationResult resultado = vendaValidator.Validate(venda);

            try
            {
                //Vai gerar uma exceção
                vendaValidator.ValidateAndThrow(venda);
            }
            catch (ValidationException excecao) //EXCEÇÃO que o metodo acima gera
            {
                Console.WriteLine("Venda inválida.");
                excecao.Errors
                       .ToList()
                       .ForEach(e => Console.WriteLine($"{e.PropertyName} : {e.ErrorMessage}"));
            }

            Console.WriteLine("Venda validada com sucesso");
            

            //if (resultado.IsValid)
            //{
            //    Console.WriteLine("Venda validada com sucesso");
            //}
            //else
            //{
            //    Console.WriteLine("Venda inválida");
            //    resultado.Errors.ToList().ForEach(erro => Console.WriteLine($" {erro.PropertyName} : {erro.ErrorMessage}"));
            //}
        }
    }
}
