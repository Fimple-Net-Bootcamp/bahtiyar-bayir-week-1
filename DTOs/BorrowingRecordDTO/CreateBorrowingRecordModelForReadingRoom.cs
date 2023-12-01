using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.DTOs.BorrowingRecordDTO
{
    internal class CreateBorrowingRecordModelForReadingRoom
    {
        public int BookId { get; set; }
        public int RoomId { get; set; }
        public DateTime ProcessDate { get; set; }
    }
}
