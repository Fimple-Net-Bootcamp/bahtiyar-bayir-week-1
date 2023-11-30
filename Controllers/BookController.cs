using AutoMapper;
using fimple_bootcamp_week_1_homework.Application.BookOperations.Queries;
using fimple_bootcamp_week_1_homework.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Controllers
{
    internal class BookController
    {
        private readonly ILibraryDbContext _libraryDbContext;
        private readonly IMapper _mapper;

        public BookController(ILibraryDbContext libraryDbContext, IMapper mapper)
        {
            _libraryDbContext = libraryDbContext;
            _mapper = mapper;
        }

        public List<BooksViewModel> GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_libraryDbContext, _mapper);
            var result = query.Handle();
            return result;
        }

        public BooksViewModel GetBookById(int id)
        {
            GetBookByIdQuery query = new GetBookByIdQuery(_libraryDbContext, _mapper);
            var result = query.Handle(id);
            return result;
        }
    }
}
