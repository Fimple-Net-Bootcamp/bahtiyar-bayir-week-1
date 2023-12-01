using AutoMapper;
using fimple_bootcamp_week_1_homework.Application.BorrowingOperations.Commands.CreateBorrowingRecord;
using fimple_bootcamp_week_1_homework.Application.BorrowingOperations.Commands.UpdateBorroiwngState;
using fimple_bootcamp_week_1_homework.Application.BorrowingOperations.Queries;
using fimple_bootcamp_week_1_homework.DBOperations;
using fimple_bootcamp_week_1_homework.DTOs.BorrowingRecordDTO;
using fimple_bootcamp_week_1_homework.Entitys;
using fimple_bootcamp_week_1_homework.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Controllers
{
    internal class BorrowingController
    {
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICustomisedMessagePrinter _logger;

        public BorrowingController(ILibraryDbContext libraryDbContext, IMapper mapper, ICustomisedMessagePrinter logger)
        {
            _dbContext = libraryDbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public List<BorrowingRecordViewModel> GetBorrowingRecords()
        {
            GetBorrowingRecordsQuery query = new GetBorrowingRecordsQuery(_dbContext, _mapper);
            var result = query.Handle();
            return result;
        }

        public ProcessStatus CreateBorrowingRecords(CreateBorrowingRecordModel model)
        {
            CreateBorrowingRecordCommand command = new CreateBorrowingRecordCommand(_dbContext, _mapper);
            command.model = model;
            try
            {
                command.Handle();
                return ProcessStatus.isSuccess;
            }catch (Exception ex)
            {
                _logger.WriteMessage(true, ConsoleColor.Red, ex.Message);
                return ProcessStatus.isFailed;
            }
        }

        public int GetNumberOfBooksBorrowingByTheUser(int id)
        {
            GetMemberBorrowingCountQuery query = new(_dbContext);
            query.id = id;
            var count = query.Handle();
            return count;
        }
        
        public ProcessStatus UpdateBorrowingState(int bookId)
        {
            UpdateBorrowingStateCommand command = new UpdateBorrowingStateCommand(_dbContext);
            command.id = bookId;
            try
            {
                command.Handle();
                return ProcessStatus.isSuccess;
            }catch(Exception ex)
            {
                _logger.WriteMessage(true, ConsoleColor.Red, ex.Message);
                return ProcessStatus.isFailed;
            }
        }
    }
}
