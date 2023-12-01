using AutoMapper;
using fimple_bootcamp_week_1_homework.Application.MemberOperations.Queries;
using fimple_bootcamp_week_1_homework.DBOperations;
using fimple_bootcamp_week_1_homework.DTOs.MemberDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Application.MemberOperations.Queries
{
    internal class GetMemberByIDQuery
    {
        public int id;
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetMemberByIDQuery(ILibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public MemberViewModel Handle()
        {
            var member = _dbContext.Members.FirstOrDefault(b => b.Id == id);
            if (member is null)
                throw new ArgumentException($"{id} numarasına sahip bir üye bulunamadı!");
            return _mapper.Map<MemberViewModel>(member);
        }
    }
}
