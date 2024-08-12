using ArticleApp.Business.Articles.Commands.Update;
using FluentValidation;

namespace ArticleApp.Business.Articles.Commands.Create.Validation
{
    public sealed class UpdateArticleCommandValidator : AbstractValidator<UpdateArticleCommand>
    {
        public UpdateArticleCommandValidator()
        {
            RuleFor(item => item.PublishedDate).GreaterThan(new DateTime(2000, 1, 1));
        }
    }
}
