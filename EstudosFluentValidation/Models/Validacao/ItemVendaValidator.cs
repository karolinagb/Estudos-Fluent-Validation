using FluentValidation;

namespace EstudosFluentValidation.Models.Validacao
{
    public class ItemVendaValidator : AbstractValidator<ItemVenda>
    {
        public ItemVendaValidator()
        {
            RuleFor(x => x.Descricao)
                .Length(3, 50).WithMessage("A descrição do item deve ter de {MinLength} a {MaxLength} caracteres");
            RuleFor(x => x.Preco)
                .GreaterThan(0).WithMessage("O preço do item deve ser maior que {ComparisonValue}");
            RuleFor(x => x.Quantidade)
                .GreaterThan(0).WithMessage("A quantidade do item deve ser maior que {ComparisonValue}");
        }
    }
}
