using fimple_bootcamp_week_1_homework.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Application.MemberOperations.Commands.DeleteMember
{
    internal class DeleteMemberCommand
    {
        public int id;
        private readonly ILibraryDbContext _dbContext;
        public DeleteMemberCommand(ILibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var Member = _dbContext.Members.SingleOrDefault(x => x.Id == id);
            if (Member is null)
                throw new ArgumentException($"{id} numarasına sahip bir üye bulunamadı!");
            _dbContext.Members.Remove(Member);
            _dbContext.SaveChanges();
        }
    }
}
