using fimple_bootcamp_week_1_homework.Application.MemberOperations.Commands.UpdateMember;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Application.MemberOperations.Commands.UpdateMember
{
    internal class UpdateMemberCommandValidator : AbstractValidator<UpdateMemberCommand>
    {
        public UpdateMemberCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.BirthDay.Date).NotEmpty().LessThan(new DateTime(DateTime.Now.Year - 15, 1, 1));
        }
    }
}
