using AutoMapper;
using fimple_bootcamp_week_1_homework.Application.BookOperations.Commands.CreateBook;
using fimple_bootcamp_week_1_homework.Application.BookOperations.Queries;
using fimple_bootcamp_week_1_homework.DTOs.AuthorDTO;
using fimple_bootcamp_week_1_homework.DTOs.BookDTO;
using fimple_bootcamp_week_1_homework.DTOs.BorrowingRecordDTO;
using fimple_bootcamp_week_1_homework.DTOs.MemberDTO;
using fimple_bootcamp_week_1_homework.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Common
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BooksViewModel>().ForMember(
                    dest => dest.Author, opt => opt.MapFrom(src => src.Author.GetName()));
            CreateMap<CreateMemberModel, Member>();
            CreateMap<Member, MemberViewModel>();
            CreateMap<CreateAuthorModel, Author>();
            CreateMap<Author, AuthorViewModel>();
            CreateMap<Borrowing, BorrowingRecordViewModel>().ForMember(
                    dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book.Title)
                ).ForMember(
                    dest => dest.MemberNameSurname, opt => opt.MapFrom(src => src.Borrower.GetName())
                ).ForMember(
                    dest => dest.MemberId, opt => opt.MapFrom(src => src.Borrower.Id)
                ).ForMember(
                    dest => dest.ProcessDate, opt => opt.MapFrom(src =>src.Date)
                );
            CreateMap<CreateBorrowingRecordModel, Borrowing>().ForMember(
                    dest => dest.BorrowerId, opt => opt.MapFrom(src => src.MemberId)
                );
        }
    }
}
