using AutoMapper;
using fimple_bootcamp_week_1_homework.DBOperations;
using fimple_bootcamp_week_1_homework.DTOs.MemberDTO;
using fimple_bootcamp_week_1_homework.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Application.MemberOperations.Commands.CreateMember
{
    internal class CreateMemberCommand
    {
        public CreateMemberModel Model { get; set; }
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateMemberCommand(ILibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var member = _dbContext.Members.SingleOrDefault(x => x.GetName().ToLower().Trim() == $"{Model.Name} {Model.Surname}".ToLower().Trim());
            if (member is not null)
                throw new InvalidOperationException($"Bu isimde bir üye kaydı daha önceden mevcut! Üye numarası {member.Id}");

            member = _mapper.Map<Member>(Model);
            _dbContext.Members.Add(member);
            _dbContext.SaveChanges();
        }
    }
}
