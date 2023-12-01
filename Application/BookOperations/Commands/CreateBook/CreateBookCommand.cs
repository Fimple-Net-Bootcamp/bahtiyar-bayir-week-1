using AutoMapper;
using fimple_bootcamp_week_1_homework.DBOperations;
using fimple_bootcamp_week_1_homework.DTOs.BookDTO;
using fimple_bootcamp_week_1_homework.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Application.BookOperations.Commands.CreateBook
{
    internal class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateBookCommand(ILibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title);
            if (book is not null)
                throw new InvalidOperationException("Bu isimde bir kitap kaydı daha önceden mevcut!");

            if (!(_dbContext.Authors.Any(x => x.Id == Model.AuthorId)))
            {
                throw new InvalidOperationException("Girilen ID'ye sahip bir yazar bulunamadı!");
            }

            book = _mapper.Map<Book>(Model);
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }
    }
}
