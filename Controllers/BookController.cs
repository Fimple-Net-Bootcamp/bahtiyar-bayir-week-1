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
using fimple_bootcamp_week_1_homework.Application.BookOperations.Commands.DeleteBook;
using fimple_bootcamp_week_1_homework.Application.BookOperations.Commands.UpdateBook;
using System.Web.Mvc;
using fimple_bootcamp_week_1_homework.DTOs.BookDTO;
using fimple_bootcamp_week_1_homework.Application.BookOperations.Commands.UpdateBookState;

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

        public BooksViewModel GetBookById(int id)
        {
            GetBookByIdQuery query = new GetBookByIdQuery(_dbContext, _mapper);
            GetBookByIDQueryValidator validator = new();
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

        public List<BooksViewModel> GetOnlyAvailableBooks()
        {
            GetAvailableBooksQuery query = new GetAvailableBooksQuery(_dbContext, _mapper);
            var result = query.Handle();
            return result;
        }

        public List<BooksViewModel> GetOnlyUnavailableBooks()
        {
            GetUnavailableBooksQuery query = new GetUnavailableBooksQuery(_dbContext, _mapper);
            var result = query.Handle();
            return result;
        }

        public ProcessStatus CreateBook(CreateBookModel model)
        {

            CreateBookCommand command = new CreateBookCommand(_dbContext, _mapper);
            command.Model = model;
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
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

        public ProcessStatus DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_dbContext);
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
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

        public ProcessStatus UpdateBook(int id, UpdateBookModel model)
        {
            UpdateBookCommand command = new UpdateBookCommand(_dbContext);
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
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
        }

        public ProcessStatus UpdateBookState(int id)
        {
            UpdateBookStateCommand command = new UpdateBookStateCommand(_dbContext);
            UpdateBookStateCommandValidator validator = new UpdateBookStateCommandValidator();
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
    }
}
