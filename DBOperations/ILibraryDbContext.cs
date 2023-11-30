using fimple_bootcamp_week_1_homework.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.DBOperations
{
    internal interface ILibraryDbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Member> Members { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<Borrowing> Borrowings { get; set; }
        int SaveChanges();
    }
}
