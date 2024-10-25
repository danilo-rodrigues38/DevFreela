using DevFreela.Application.Commands.UpdateProject;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator()
        {
            RuleFor ( p => p.Description )
                .NotEmpty( )
                    .WithMessage ( "Descrição não pode estar vazia." )
                .MaximumLength ( 255 )
                    .WithMessage ( "Tamanho máximo da Descrição é de 255 caracteres." );

            RuleFor ( p => p.Title )
                .NotEmpty( )
                    .WithMessage ( "Título não pode estar vazio." )
                .MaximumLength ( 50 )
                .WithMessage ( "Tamanho máximo do Título é de 30 caracteres." );
        }
    }
}
