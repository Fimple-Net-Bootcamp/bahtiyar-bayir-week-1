using fimple_bootcamp_week_1_homework.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Application.BookOperations.Commands.UpdateBookState
{
    internal class UpdateBookStateCommand
    {
        public int id;
        private readonly ILibraryDbContext _dbContext;
        public UpdateBookStateCommand(ILibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Id == id);
            if (book is null)
                throw new ArgumentException($"{id} numarasına sahip bir kitap bulunamadı!");
            book.State = !book.State;
            _dbContext.SaveChanges();
        }
    }
}
