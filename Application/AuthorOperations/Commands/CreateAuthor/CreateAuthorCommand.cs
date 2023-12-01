using AutoMapper;
using fimple_bootcamp_week_1_homework.DBOperations;
using fimple_bootcamp_week_1_homework.DTOs.AuthorDTO;
using fimple_bootcamp_week_1_homework.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Application.AuthorOperations.Commands.CreateAuthor
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
            var author = _dbContext.Authors.SingleOrDefault(x => x.GetName().ToLower().Trim() == $"{Model.Name} {Model.Surname}".ToLower().Trim());
            if (author is not null)
                throw new InvalidOperationException($"Bu isimde bir yazar kaydı daha önceden mevcut! Üye numarası {author.Id}");

            author = _mapper.Map<Author>(Model);
            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();
        }
    }
}
