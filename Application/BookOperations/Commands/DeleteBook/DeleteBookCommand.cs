using AutoMapper;
using fimple_bootcamp_week_1_homework.Application.BookOperations.Commands.CreateBook;
using fimple_bootcamp_week_1_homework.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Application.BookOperations.Commands.DeleteBook
{
    internal class DeleteBookCommand
    {
        public int id;
        private readonly ILibraryDbContext _dbContext;
        public DeleteBookCommand(ILibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var Book = _dbContext.Books.SingleOrDefault(x => x.Id == id);
            if (Book is null)
                throw new ArgumentException($"{id} numarasına sahip bir kitap bulunamadı!");
            _dbContext.Books.Remove(Book);
            _dbContext.SaveChanges();
        }
    }
}
