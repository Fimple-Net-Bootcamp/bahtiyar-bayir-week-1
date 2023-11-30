using AutoMapper;
using fimple_bootcamp_week_1_homework.DBOperations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Application.BookOperations.Queries
{
    internal class GetBookByIdQuery
    {
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBookByIdQuery(ILibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BooksViewModel Handle(int id)
        {
            var bookList = _dbContext.Books.Include(x => x.Author).FirstOrDefault(b => b.Id == id);
            return _mapper.Map<BooksViewModel>(bookList);
        }
    }
}
