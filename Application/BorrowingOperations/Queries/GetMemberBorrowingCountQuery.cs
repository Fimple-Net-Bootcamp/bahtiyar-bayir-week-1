using fimple_bootcamp_week_1_homework.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Application.BorrowingOperations.Queries
{
    internal class GetMemberBorrowingCountQuery
    {
        public int id;
        private readonly ILibraryDbContext _dbContext;

        public GetMemberBorrowingCountQuery(ILibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Handle()
        {
            int count = _dbContext.Borrowings.Where(b => b.BorrowerId == id).Count();
            return count;
        }
    }
}
