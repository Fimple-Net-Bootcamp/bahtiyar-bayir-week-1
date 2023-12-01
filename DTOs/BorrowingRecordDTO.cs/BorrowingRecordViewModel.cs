using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.DTOs.BorrowingRecordDTO.cs
{
    internal class BorrowingRecordViewModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public int MemberId { get; set; }
        public string MemberNameSurname { get; set; }
        public DateTime ProcessDate { get; set; }
    }
}
