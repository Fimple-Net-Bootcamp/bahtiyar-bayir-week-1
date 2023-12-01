using AutoMapper;
using fimple_bootcamp_week_1_homework.Application.MemberOperations.Commands.CreateMember;
using fimple_bootcamp_week_1_homework.Application.MemberOperations.Commands.DeleteMember;
using fimple_bootcamp_week_1_homework.Application.MemberOperations.Commands.UpdateMember;
using fimple_bootcamp_week_1_homework.Application.MemberOperations.Queries;
using fimple_bootcamp_week_1_homework.DBOperations;
using fimple_bootcamp_week_1_homework.DTOs.MemberDTO;
using fimple_bootcamp_week_1_homework.Entitys;
using fimple_bootcamp_week_1_homework.Services;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Controllers
{
    internal class MemberController
    {
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICustomisedMessagePrinter _logger;

        public MemberController(ILibraryDbContext libraryDbContext, IMapper mapper, ICustomisedMessagePrinter logger)
        {
            _dbContext = libraryDbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public List<MemberViewModel> GetMembers()
        {
            GetMembersQuery query = new GetMembersQuery(_dbContext, _mapper);
            var result = query.Handle();
            return result;
        }

        public MemberViewModel GetMemberById(int id)
        {
            GetMemberByIDQuery query = new GetMemberByIDQuery(_dbContext, _mapper);
            GetMemberByIDQueryValidator validator = new();
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

        public List<MemberViewModel> GetOnlyActiveMembers()
        {
            GetActiveMembersQuery query = new GetActiveMembersQuery(_dbContext, _mapper);
            var result = query.Handle();
            return result;
        }

        public List<MemberViewModel> GetOnlyInctiveMembers()
        {
            GetInactiveMembersQuery query = new GetInactiveMembersQuery(_dbContext, _mapper);
            var result = query.Handle();
            return result;
        }

        public ProcessStatus CreateMember(CreateMemberModel model)
        {

            CreateMemberCommand command = new CreateMemberCommand(_dbContext, _mapper);
            command.Model = model;
            CreateMemberCommandValidator validator = new CreateMemberCommandValidator();
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
        
        public ProcessStatus DeleteMember(int id)
        {
            DeleteMemberCommand command = new DeleteMemberCommand(_dbContext);
            DeleteMemberCommandValidator validator = new DeleteMemberCommandValidator();
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
        public ProcessStatus UpdateMember(int id, UpdateMemberModel model)
        {
            UpdateMemberCommand command = new UpdateMemberCommand(_dbContext);
            UpdateMemberCommandValidator validator = new UpdateMemberCommandValidator();
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
    }
}
