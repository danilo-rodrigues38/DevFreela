using DevFreela.Application.Commands.CreateComment;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor ( p => p.Content )
                .NotEmpty ( )
                    .WithMessage ( "Comentário não pode estar vazio." )
                .MaximumLength ( 255 )
                    .WithMessage ( "Tamanho máxio do comentário é de 255 caracteres." );
        }
    }
}
