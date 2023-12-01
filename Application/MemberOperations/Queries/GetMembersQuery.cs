using AutoMapper;
using fimple_bootcamp_week_1_homework.DBOperations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Application.MemberOperations.Queries
{
    public class MembersViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public DateTime BirthDay { get; set; }
        public Boolean State { get; set; }
    }
    internal class GetMembersQuery
    {
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetMembersQuery(ILibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<MembersViewModel> Handle()
        {
            var Members = _dbContext.Members.OrderBy(x => x.Id).ToList();
            return new List<MembersViewModel>(_mapper.Map<List<MembersViewModel>>(Members));
        }
    }
}
