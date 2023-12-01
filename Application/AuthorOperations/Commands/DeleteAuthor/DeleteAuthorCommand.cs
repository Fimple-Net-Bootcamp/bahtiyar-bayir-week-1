using fimple_bootcamp_week_1_homework.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Application.AuthorOperations.Commands.DeleteAuthor
{
    internal class DeleteAuthorCommand
    {
        public int id;
        private readonly ILibraryDbContext _dbContext;
        public DeleteAuthorCommand(ILibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var Author = _dbContext.Authors.SingleOrDefault(x => x.Id == id);
            if (Author is null)
                throw new ArgumentException($"{id} numarasına sahip bir yazar bulunamadı!");
            _dbContext.Authors.Remove(Author);
            _dbContext.SaveChanges();
        }
    }
}
