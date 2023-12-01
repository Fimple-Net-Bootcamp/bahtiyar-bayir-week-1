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
                throw new InvalidOperationException($"{Id} numarasına sahip bir kitap bulunamadı!");
            }
            /*if (!(_dbContext.Authors.Any(x => x.Id == Model.AuthorId)))
                throw new InvalidOperationException("Girilen ID'ye sahip bir yazar bulunamadı!");

            Member.Title = Model.Title != "string" ? Model.Title : Member.Title;
            Member.AuthorId = Model.AuthorId != default ? Model.AuthorId : Member.AuthorId;
            Member.PublishDate = Model.PublishDate != default ? Model.PublishDate : Member.PublishDate;*/
            _dbContext.SaveChanges();
        }
    }
}
