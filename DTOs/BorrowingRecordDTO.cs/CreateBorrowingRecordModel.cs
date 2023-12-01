using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.DTOs.BorrowingRecordDTO.cs
{
    internal class CreateBorrowingRecordModel
    {
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public DateTime ProcessDate { get; set; }
    }
}
