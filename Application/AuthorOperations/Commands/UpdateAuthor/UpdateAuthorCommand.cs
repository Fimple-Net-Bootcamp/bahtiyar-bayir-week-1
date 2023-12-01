using fimple_bootcamp_week_1_homework.DBOperations;
using fimple_bootcamp_week_1_homework.DTOs.AuthorDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Application.AuthorOperations.Commands.UpdateAuthor
{
    internal class UpdateAuthorCommand
    {
        public int Id { get; set; }
        public UpdateAuthorModel Model { get; set; }
        private readonly ILibraryDbContext _dbContext;

        public UpdateAuthorCommand(ILibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var Author = _dbContext.Authors.FirstOrDefault(book => book.Id == Id);
            if (Author is null)
            {
                throw new ArgumentException($"{Id} numarasına sahip bir yazar bulunamadı!");
            }

            Author.Name = Model.Name != "string" ? Model.Name : Author.Name;
            Author.Surname = Model.Surname != default ? Model.Surname : Author.Surname;
            _dbContext.SaveChanges();
        }
    }
}
