using AutoMapper;
using fimple_bootcamp_week_1_homework.DBOperations;
using fimple_bootcamp_week_1_homework.DTOs.AuthorDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Application.AuthorOperations.Command.CreateAuthor
{
    internal class CreateAuthorCommand
    {
        public CreateAuthorModel Model { get; set; }
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateAuthorCommand(ILibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var member = _dbContext.Authors.SingleOrDefault(x => x.GetName().ToLower().Trim() == $"{Model.Name} {Model.Surname}".ToLower().Trim());
            if (member is not null)
                throw new InvalidOperationException($"Bu isimde bir üye kaydı daha önceden mevcut! Üye numarası {member.Id}");

            member = _mapper.Map<Author>(Model);
            _dbContext.Authors.Add(member);
            _dbContext.SaveChanges();
        }
    }
}
