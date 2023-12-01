using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.DTOs.BookDTO
{
    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
