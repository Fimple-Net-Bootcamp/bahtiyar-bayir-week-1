using AutoMapper;
using fimple_bootcamp_week_1_homework.Application.BookOperations.Commands.CreateBook;
using fimple_bootcamp_week_1_homework.Application.BookOperations.Queries;
using fimple_bootcamp_week_1_homework.DTOs.BookDTO;
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
        }
    }
}
