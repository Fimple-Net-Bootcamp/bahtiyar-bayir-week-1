using fimple_bootcamp_week_1_homework.DBOperations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Application.AuthorOperations.Queries
{
    internal class GetAuthorBookCountQuery
    {
        public int id;
        private readonly ILibraryDbContext _dbContext;

        public GetAuthorBookCountQuery(ILibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Handle()
        {
            var count = _dbContext.Books.Include(x => x.Author).Where(b => b.AuthorId == id).Count();
            return count;
        }
    }
}
