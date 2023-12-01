using AutoMapper;
using fimple_bootcamp_week_1_homework.DBOperations;
using fimple_bootcamp_week_1_homework.DTOs.MemberDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Application.MemberOperations.Commands.UpdateMemberState
{
    internal class UpdateMemberStateCommand
    {
        public int id;
        private readonly ILibraryDbContext _dbContext;
        public UpdateMemberStateCommand(ILibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var member = _dbContext.Members.FirstOrDefault(b => b.Id == id);
            if (member is null)
                throw new ArgumentException($"{id} numarasına sahip bir üye bulunamadı!");
            member.State = false;
            _dbContext.SaveChanges();
        }
    }
}
