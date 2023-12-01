using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Application.BookOperations.Queries
{
    internal class GetBookByIDQueryValidator : AbstractValidator<GetBookByIdQuery>
    {
        public GetBookByIDQueryValidator()
        {
            RuleFor(command => command.title).NotEmpty().MinimumLength(4).MaximumLength(10);
        }
    }
}
