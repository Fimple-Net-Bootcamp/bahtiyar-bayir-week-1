using AutoMapper;
using fimple_bootcamp_week_1_homework.Application.BookOperations.Queries;
using fimple_bootcamp_week_1_homework.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Application.MemberOperations.Queries
{
    internal class GetActiveMembersQuery
    {
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetActiveMembersQuery(ILibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<MembersViewModel> Handle()
        {
            var Members = _dbContext.Members.Where(x => x.State == true)
                                            .OrderBy(x => x.Id).ToList();
            return new List<MembersViewModel>(_mapper.Map<List<MembersViewModel>>(Members));
        }
    }
}
