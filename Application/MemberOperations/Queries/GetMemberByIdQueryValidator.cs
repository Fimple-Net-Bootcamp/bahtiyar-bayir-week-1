using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Application.MemberOperations.Queries
{
    internal class GetMemberByIDQueryValidator : AbstractValidator<GetMemberByIDQuery>
    {
        public GetMemberByIDQueryValidator()
        {
            RuleFor(command => command.id).GreaterThan(0).LessThan(500);
        }
    }
}
