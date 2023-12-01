using AutoMapper;
using fimple_bootcamp_week_1_homework.Application.BookOperations.Queries;
using fimple_bootcamp_week_1_homework.DBOperations;
using fimple_bootcamp_week_1_homework.DTOs.MemberDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Application.MemberOperations.Queries
{
    internal class GetInactiveMembersQuery
    {
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetInactiveMembersQuery(ILibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<MemberViewModel> Handle()
        {
            var Members = _dbContext.Members.Where(x => x.State == false)
                                            .OrderBy(x => x.Id).ToList();
            return new List<MemberViewModel>(_mapper.Map<List<MemberViewModel>>(Members));
        }
    }
}
