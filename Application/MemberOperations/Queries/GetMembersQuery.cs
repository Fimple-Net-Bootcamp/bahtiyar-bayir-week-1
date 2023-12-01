using AutoMapper;
using fimple_bootcamp_week_1_homework.DBOperations;
using fimple_bootcamp_week_1_homework.DTOs.MemberDTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Application.MemberOperations.Queries
{
    internal class GetMembersQuery
    {
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetMembersQuery(ILibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<MemberViewModel> Handle()
        {
            var Members = _dbContext.Members.OrderBy(x => x.Id).ToList();
            return new List<MemberViewModel>(_mapper.Map<List<MemberViewModel>>(Members));
        }
    }
}
