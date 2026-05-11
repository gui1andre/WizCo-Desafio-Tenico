using FluentValidation;
using WizCoDesafio.Application.Pedido.DTO;

namespace WizCoDesafio.Application.Validators
{
    public class FiltroPedidoDTOValidator : AbstractValidator<FiltroPedidoDTO>
    {
        public FiltroPedidoDTOValidator()
        {
            RuleFor(x => x)
                .Must(x => !x.DataInicio.HasValue || !x.DataFim.HasValue || x.DataInicio.Value <= x.DataFim.Value)
                .WithMessage("DataInicio não pode ser maior que DataFim.");

            RuleFor(x => x)
                .Must(x => !x.DataInicio.HasValue || !x.DataFim.HasValue || x.DataFim.Value >= x.DataInicio.Value)
                .WithMessage("DataFim não pode ser menor que DataInicio.");
        }
    }
}
