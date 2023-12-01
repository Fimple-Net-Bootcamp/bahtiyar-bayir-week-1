using AutoMapper;
using fimple_bootcamp_week_1_homework.Application.BookOperations.Queries;
using fimple_bootcamp_week_1_homework.DBOperations;
using fimple_bootcamp_week_1_homework.Services;
using System;
using System.Collections.Generic;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fimple_bootcamp_week_1_homework.Entitys;
using fimple_bootcamp_week_1_homework.Application.BookOperations.Commands.CreateBook;
using Microsoft.EntityFrameworkCore;

namespace fimple_bootcamp_week_1_homework.Controllers
{
    internal class BookController
    {
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICustomisedMessagePrinter _logger;

        public BookController(ILibraryDbContext libraryDbContext, IMapper mapper, ICustomisedMessagePrinter logger)
        {
            _dbContext = libraryDbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public List<BooksViewModel> GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_dbContext, _mapper);
            var result = query.Handle();
            return result;
        }

        public BooksViewModel GetBookByTitle(string title)
        {
            GetBookByIdQuery query = new GetBookByIdQuery(_dbContext, _mapper);
            GetBookByIDQueryValidator validator = new();
            query.title = title;
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

        public ProcessStatus CreateBook(CreateBookModel model)
        {

            CreateBookCommand query = new CreateBookCommand(_dbContext, _mapper);
            query.Model = model;
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            try
            {
                validator.ValidateAndThrow(query);
                query.Handle();
                return ProcessStatus.isSuccess;
            }
            catch (Exception ex)
            {
                _logger.WriteMessage(true, ConsoleColor.Red, ex.Message);
                return ProcessStatus.isFailed;
            }
        }
    }
}
