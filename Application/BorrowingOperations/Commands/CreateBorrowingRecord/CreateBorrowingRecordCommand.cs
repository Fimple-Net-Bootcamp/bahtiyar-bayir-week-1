using AutoMapper;
using fimple_bootcamp_week_1_homework.DBOperations;
using fimple_bootcamp_week_1_homework.DTOs.BorrowingRecordDTO.cs;
using fimple_bootcamp_week_1_homework.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Application.BorrowingOperations.Commands.CreateBorrowingRecord
{
    internal class CreateBorrowingRecordCommand
    {
        public CreateBorrowingRecordModel model;
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateBorrowingRecordCommand(ILibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            if (!(_dbContext.Books.Any(book => book.Id == model.BookId)))
                throw new InvalidDataException("Bu ID'ye ait bir kitap kaydı bulunamadı!");
            if(!(_dbContext.Members.Any(member => member.Id == model.MemberId)))
                throw new InvalidDataException("Bu ID'ye ait bir üye kaydı bulunamadı!");
            var record = _mapper.Map<Borrowing>(model);
            _dbContext.Borrowings.Add(record);
            _dbContext.SaveChanges();
            Console.WriteLine("Başarılı");

        }
    }
}
