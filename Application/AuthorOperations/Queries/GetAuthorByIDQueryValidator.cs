using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Application.AuthorOperations.Queries
{
    internal class GetAuthorByIDQueryValidator : AbstractValidator<GetAuthorByIDQuery>
    {
        public GetAuthorByIDQueryValidator()
        {
            RuleFor(command => command.id).GreaterThan(0).LessThan(500);
        }
    }
}
