using fimple_bootcamp_week_1_homework.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Application.BorrowingOperations.Commands.UpdateBorroiwngState
{
    internal class UpdateBorrowingStateCommand
    {
        public int id;
        private readonly ILibraryDbContext _dbContext;

        public UpdateBorrowingStateCommand(ILibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var record = _dbContext.Borrowings.FirstOrDefault(x => x.BookId == id && x.state == false);
            if(record is null)
                throw new InvalidDataException("Bu kitap ID'sine ait bir ödünç alma kaydı bulunamadı!");
            if(!record.state)
            {
                record.state = true;
                _dbContext.SaveChanges();
            }
        }
    }
}
