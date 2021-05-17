using EstudosFluentValidation.Models.Enums;
using FluentValidation;
using System;

namespace EstudosFluentValidation.Models.Validacao
{
    public class VendaValidator : AbstractValidator<Venda>
    {
        public VendaValidator()
        {
            //RuleFor = especifica qual propriedade da classe queremos validar
            RuleFor(x => x.Data)
                .LessThanOrEqualTo(DateTime.Today).WithMessage("A data da venda deve ser menor ou igual a data atual")
                .NotNull().WithMessage("Informe a data");
            RuleFor(x => x.Total)
                .GreaterThan(0).When(x => x.Tipo == TipoVenda.Padrao).WithMessage("O total da venda deve ser maior que zero");
            RuleForEach(x => x.Itens)
                .NotNull().WithMessage("Itens da venda não pode ser nula")
                .Must(x => x != null ? true : false).WithMessage("A venda deve possuir pelo menos 1 item")
                //Validação em cascata
                //Para validar cada item dentro da venda ou a partir da venda 
                //Cada item vai ser validado de acordo com o Validador determinado
                .SetValidator(new ItemVendaValidator());

            When(x => x.Tipo == TipoVenda.Brinde, () =>
            {
                RuleFor(x => x.Total)
                    .Equal(0).WithMessage("Para venda do tipo brinde o total deve ser igual a {ComparisonValue}");
                RuleFor(x => x.Itens.Count)
                    .Equal(1).WithMessage("Vendas do tipo brinde devem conter apenas {ComparisonValue} item");
            });
        }
    }
}
