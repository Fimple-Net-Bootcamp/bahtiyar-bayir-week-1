using AutoMapper;
using fimple_bootcamp_week_1_homework.DBOperations;
using fimple_bootcamp_week_1_homework.DTOs.BookDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Application.BookOperations.Commands.UpdateBook
{
    internal class UpdateBookCommand
    {
        public int Id { get; set; }
        public UpdateBookModel Model { get; set; }
        private readonly ILibraryDbContext _dbContext;

        public UpdateBookCommand(ILibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var Book = _dbContext.Books.FirstOrDefault(book => book.Id == Id);
            if (Book is null)
            {
                throw new InvalidOperationException($"{Id} numarasına sahip bir kitap bulunamadı!");
            }
            if (!(_dbContext.Authors.Any(x => x.Id == Model.AuthorId)))
                throw new InvalidOperationException("Girilen ID'ye sahip bir yazar bulunamadı!");

            Book.Title = Model.Title != "string" ? Model.Title : Book.Title;
            Book.AuthorId = Model.AuthorId != default ? Model.AuthorId : Book.AuthorId;
            Book.PublishDate = Model.PublishDate != default ? Model.PublishDate : Book.PublishDate;
            _dbContext.SaveChanges();
        }
    }
}
