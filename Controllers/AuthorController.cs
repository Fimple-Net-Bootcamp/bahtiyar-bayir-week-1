using AutoMapper;
using fimple_bootcamp_week_1_homework.Application.AuthorOperations.Commands.CreateAuthor;
using fimple_bootcamp_week_1_homework.Application.AuthorOperations.Commands.DeleteAuthor;
using fimple_bootcamp_week_1_homework.Application.AuthorOperations.Commands.UpdateAuthor;
using fimple_bootcamp_week_1_homework.Application.AuthorOperations.Commands.UpdateAuthorState;
using fimple_bootcamp_week_1_homework.Application.AuthorOperations.Queries;
using fimple_bootcamp_week_1_homework.DBOperations;
using fimple_bootcamp_week_1_homework.DTOs.AuthorDTO;
using fimple_bootcamp_week_1_homework.Entitys;
using fimple_bootcamp_week_1_homework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Controllers
{
    internal class AuthorController
    {
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICustomisedMessagePrinter _logger;

        public AuthorController(ILibraryDbContext libraryDbContext, IMapper mapper, ICustomisedMessagePrinter logger)
        {
            _dbContext = libraryDbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public List<AuthorViewModel> GetAuthors()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_dbContext, _mapper);
            var result = query.Handle();
            return result;
        }

        /*public AuthorViewModel GetAuthorById(int id)
        {
            GetAuthorByIDQuery query = new GetAuthorByIDQuery(_dbContext, _mapper);
            GetAuthorByIDQueryValidator validator = new();
            query.id = id;
            try
            {
                validator.ValidateAndThrow(query);
                var result = query.Handle();
                return result;
            }
            catch (Exception ex)
            {
                _logger.WriteMessage(true, ConsoleColor.Red, ex.Message);
                return null;
            }
        }

        public ProcessStatus CreateAuthor(CreateAuthorModel model)
        {

            CreateAuthorCommand command = new CreateAuthorCommand(_dbContext, _mapper);
            command.Model = model;
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            try
            {
                validator.ValidateAndThrow(command);
                command.Handle();
                return ProcessStatus.isSuccess;
            }
            catch (Exception ex)
            {
                _logger.WriteMessage(true, ConsoleColor.Red, ex.Message);
                return ProcessStatus.isFailed;
            }
        }

        public ProcessStatus DeleteAuthor(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_dbContext);
            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            command.id = id;
            try
            {
                validator.ValidateAndThrow(command);
                command.Handle();
                return ProcessStatus.isSuccess;
            }
            catch (Exception ex)
            {
                _logger.WriteMessage(true, ConsoleColor.Red, ex.Message);
                return ProcessStatus.isFailed;
            }
        }

        public ProcessStatus UpdateAuthor(int id, UpdateAuthorModel model)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_dbContext);
            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            command.Id = id;
            command.Model = model;
            try
            {
                validator.ValidateAndThrow(command);
                command.Handle();
                return ProcessStatus.isSuccess;
            }
            catch (Exception ex)
            {
                _logger.WriteMessage(true, ConsoleColor.Red, ex.Message);
                return ProcessStatus.isFailed;
            }
        }*/
    }
}
