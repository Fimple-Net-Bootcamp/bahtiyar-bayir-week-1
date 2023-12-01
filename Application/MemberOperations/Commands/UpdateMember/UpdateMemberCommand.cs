using fimple_bootcamp_week_1_homework.DBOperations;
using fimple_bootcamp_week_1_homework.DTOs.MemberDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Application.MemberOperations.Commands.UpdateMember
{
    internal class UpdateMemberCommand
    {
        public int Id { get; set; }
        public UpdateMemberModel Model { get; set; }
        private readonly ILibraryDbContext _dbContext;

        public UpdateMemberCommand(ILibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var Member = _dbContext.Members.FirstOrDefault(book => book.Id == Id);
            if (Member is null)
            {
                throw new ArgumentException($"{Id} numarasına sahip bir üye bulunamadı!");
            }

            Member.Name = Model.Name != "string" ? Model.Name : Member.Name;
            Member.Surname = Model.Surname != default ? Model.Surname : Member.Surname;
            Member.BirthDay = Model.BirthDay != default ? Model.BirthDay : Member.BirthDay;
            _dbContext.SaveChanges();
        }
    }
}
