using AutoMapper;
using fimple_bootcamp_week_1_homework.DBOperations;
using fimple_bootcamp_week_1_homework.DTOs.BorrowingRecordDTO.cs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Application.BorrowingOperations.Queries
{
    internal class GetBorrowingRecordsQuery
    {
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBorrowingRecordsQuery(ILibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<BorrowingRecordViewModel> Handle()
        {
            var records = _dbContext.Borrowings.Include(x => x.Book).Include(x => x.Borrower).ToList();
            if(records is null)
                throw new InvalidOperationException("Hiç bir kayıt mevcut değil!");
            return new List<BorrowingRecordViewModel>(_mapper.Map<List<BorrowingRecordViewModel>>(records));
        }
    }
}
