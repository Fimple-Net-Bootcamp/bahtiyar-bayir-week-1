using AutoMapper;
using fimple_bootcamp_week_1_homework.DBOperations;
using fimple_bootcamp_week_1_homework.DTOs.BookDTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Application.BookOperations.Queries
{
    internal class GetBookByIDQuery
    {
        public int id;
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBookByIDQuery(ILibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public BooksViewModel Handle()
        {
            var book = _dbContext.Books.Include(x => x.Author).FirstOrDefault(b => b.Id == id);
            if(book is null)
                throw new ArgumentException($"{id} numarasına sahip bir kitap bulunamadı!");
            return _mapper.Map<BooksViewModel>(book);
        }
    }
}
