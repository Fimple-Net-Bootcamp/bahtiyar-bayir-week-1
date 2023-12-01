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
    internal class GetAuthorByIDQuery
    {
        public int id;
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAuthorByIDQuery(ILibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public AuthorViewModel Handle()
        {
            var book = _dbContext.Authors.FirstOrDefault(b => b.Id == id);
            if (book is null)
                throw new ArgumentException($"{id} numarasına sahip bir kitap bulunamadı!");
            return _mapper.Map<AuthorViewModel>(book);
        }
    }
}
