using ArticleApp.Business.Articles.Commands.Create;
using FluentValidation;

namespace ArticleApp.Business.Articles.Commands.Create.Validation
{
    public sealed class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
    {
        public CreateArticleCommandValidator()
        {
            RuleFor(item => item.Title).NotEmpty();
            RuleFor(item => item.Content).NotEmpty();
            RuleFor(item => item.PublishedDate).NotEmpty();
        }
    }
}
