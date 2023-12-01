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
    internal class GetUnavailableBooksQuery
    {
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetUnavailableBooksQuery(ILibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.Include(x => x.Author)
                                            .Where(x => x.State == false)
                                            .OrderBy(x => x.Id).ToList();
            return new List<BooksViewModel>(_mapper.Map<List<BooksViewModel>>(bookList));
        }
    }
}
