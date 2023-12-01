using AutoMapper;
using fimple_bootcamp_week_1_homework.DBOperations;
using fimple_bootcamp_week_1_homework.DTOs.AuthorDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Application.AuthorOperations.Queries
{
    internal class GetAuthorsQuery
    {
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAuthorsQuery(ILibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<AuthorViewModel> Handle()
        {
            var bookList = _dbContext.Authors.OrderBy(x => x.Id).ToList();
            return new List<AuthorViewModel>(_mapper.Map<List<AuthorViewModel>>(bookList));
        }
    }
}
