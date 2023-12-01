using fimple_bootcamp_week_1_homework.Application.MemberOperations.Commands.DeleteMember;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Application.MemberOperations.Commands.DeleteMember
{
    internal class DeleteMemberCommandValidator : AbstractValidator<DeleteMemberCommand>
    {
        public DeleteMemberCommandValidator()
        {
            RuleFor(command => command.id).GreaterThan(0).LessThan(500);
        }
    }
}
