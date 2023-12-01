using AutoMapper;
using fimple_bootcamp_week_1_homework.Controllers;
using fimple_bootcamp_week_1_homework.DBOperations;
using fimple_bootcamp_week_1_homework.Entitys;
using fimple_bootcamp_week_1_homework.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace fimple_bootcamp_week_1_homework.Manager
{
    internal class Manager : IManager
    {
        private readonly ILibraryDbContext dbContext;
        private readonly ICustomisedMessagePrinter logger;
        private readonly IMapper mapper;

        public Manager(ILibraryDbContext dbContext, ICustomisedMessagePrinter logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;
        }

        public void Start()
        {
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                logger.WriteTitle(ConsoleColor.Yellow, "Welcome to the ",
                                      ConsoleColor.Green, "Fimple ",
                                      ConsoleColor.Yellow, "Library");

                logger.WriteMessage(true, ConsoleColor.White, "\tSelect the operation you want to perform:\r\n",
                                          ConsoleColor.Yellow, "\tLibrary transaction menus:\r\n",
                                          ConsoleColor.Magenta, "\t\t1  ", ConsoleColor.White, "- Member borrowing transaction record\r\n",
                                          ConsoleColor.Magenta, "\t\t2  ", ConsoleColor.White, "- Member book return process\r\n",
                                          ConsoleColor.Magenta, "\t\t3  ", ConsoleColor.White, "- Collect books from reading rooms\r\n",
                                          ConsoleColor.Yellow, "\tBook transaction menus:\r\n",
                                          ConsoleColor.Magenta, "\t\t4  ", ConsoleColor.White, "- Create book record\r\n",
                                          ConsoleColor.Magenta, "\t\t5  ", ConsoleColor.White, "- Delete book record\r\n",
                                          ConsoleColor.Magenta, "\t\t6  ", ConsoleColor.White, "- Update book record\r\n",
                                          ConsoleColor.Magenta, "\t\t7  ", ConsoleColor.White, "- List of all books\r\n",
                                          ConsoleColor.Magenta, "\t\t8  ", ConsoleColor.White, "- Find books by ID\r\n",
                                          ConsoleColor.Magenta, "\t\t9  ", ConsoleColor.White, "- List the books that can be borrowed\r\n",
                                          ConsoleColor.Magenta, "\t\t10 ", ConsoleColor.White, "- List borrowed books\r\n",
                                          ConsoleColor.Yellow, "\tMember transactions menus:\r\n",
                                          ConsoleColor.Magenta, "\t\t11 ", ConsoleColor.White, "- Create member record\r\n",
                                          ConsoleColor.Magenta, "\t\t12 ", ConsoleColor.White, "- Delete member record\r\n",
                                          ConsoleColor.Magenta, "\t\t13 ", ConsoleColor.White, "- Update member record\r\n",
                                          ConsoleColor.Magenta, "\t\t14 ", ConsoleColor.White, "- Change member active passive status\r\n",
                                          ConsoleColor.Magenta, "\t\t15 ", ConsoleColor.White, "- List of all members\r\n",
                                          ConsoleColor.Magenta, "\t\t16 ", ConsoleColor.White, "- Find members by ID\r\n",
                                          ConsoleColor.Magenta, "\t\t17 ", ConsoleColor.White, "- List of only active members\r\n",
                                          ConsoleColor.Magenta, "\t\t18 ", ConsoleColor.White, "- List of only inactive members\r\n",
                                          ConsoleColor.Magenta, "\t\t19 ", ConsoleColor.White, "- Print all members with their books\r\n",
                                          ConsoleColor.Yellow, "\tAuthor operations menus:\r\n",
                                          ConsoleColor.Magenta, "\t\t20 ", ConsoleColor.White, "- Create member record\r\n",
                                          ConsoleColor.Magenta, "\t\t21 ", ConsoleColor.White, "- Delete member record\r\n",
                                          ConsoleColor.Magenta, "\t\t22 ", ConsoleColor.White, "- Update member record\r\n",
                                          ConsoleColor.Magenta, "\t\t23 ", ConsoleColor.White, "- List of all authors\r\n",
                                          ConsoleColor.Magenta, "\t\t24 ", ConsoleColor.White, "- Find author by ID\r\n",
                                          ConsoleColor.Magenta, "\t\t25 ", ConsoleColor.White, "- Exit\r\n\r\n");
                logger.WriteMessage(false, ConsoleColor.Cyan, "Your choice>");
                switch (Console.ReadLine())
                {
                    /*case "1": CreateBookBorrowingRecord(); break;
                    case "2": ReturnBorrowedBook(); break;
                    case "3": CollectBooksFromReadingRoom(); break;*/
                    case "4": CreateBookRecord(); break;
                   /* case "5": DeleteBookRecord(); break;
                    case "6":UpdateBookRecord(); break; */
                    case "7": PrintListofAllBooks(); break;
                    case "8": GetBookById(); break;
                    /*case "9": PrintOnlyAvailableForBorrowBookList(); break;
                    case "10": PrintOnlyUnavailableForBorrowBookList(); break;
                    case "11": CreateMemberRecord(); break;
                    case "12": DeleteMemberRecord(); break;
                    case "13": UpdateMemberRecord(); break;
                    case "14": ChangeMemberStatus(); break;
                    case "15": PrintAllMemberList(); break;
                    case "16": GetMemberById(); break;
                    case "17": PrintOnlyActiveMemberList(); break;
                    case "18": PrintOnlyPassiveMemberList(); break;
                    case "19": PrintAllMembersWithBorrowedBooks(); break;
                    case "20": CreateAuthorRecord(); break;
                    case "21": DeleteAuthorRecord(); break;
                    case "22": UpdateAuthorRecord(); break;
                    case "23": PrintAllAuthorList(); break;
                    case "24": GetAuthorById(); break;*/
                    case "25": loop = false; break;
                }
            }
        }
        /// <summary>
        ///  Function defined for the "4 Create book record" menu.
        /// </summary>
        internal void CreateBookRecord()
        {
            Console.Clear();
            logger.WriteTitle(ConsoleColor.Blue, "4 - Book Record Creation Menu");
            Console.ReadKey();
            try
            {

            }

        }

        /// <summary>
        ///  Function defined for the "7 List all books" menu.
        /// </summary>
        internal void PrintListofAllBooks()
        {
            Console.Clear();
            logger.WriteTitle(ConsoleColor.Blue, "7 - List of Registered Books ");
            logger.WriteMessage(true, ConsoleColor.DarkCyan, "ID  -                Book Title                |             Author             | Publish Date |   Status   \r\n" + new string('-', 143));
            BookController controller = new BookController(dbContext, mapper);
            var bookList = controller.GetBooks();
            bookList.ForEach(x =>
            {

                logger.WriteMessage(true, ConsoleColor.Magenta, $"{x.Id,-3} - ",
                                            ConsoleColor.Yellow, $"{x.Title,-40}",
                                            ConsoleColor.White, $" | {x.Author,-30} | ",
                                            ConsoleColor.White, $" {x.PublishDate.ToString("yyyy.MM.dd")}  | ");
            });

            logger.WriteMessage(true, ConsoleColor.Red, "\r\nPress a key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        ///  Function defined for the "8 Get book by ID" menu.
        /// </summary>
        internal void GetBookById()
        {
            Console.Clear();
            logger.WriteTitle(ConsoleColor.Blue, "7 - List of Registered Books ");
            logger.WriteMessage(true, ConsoleColor.Yellow, "Enter the ID of the book you want to see>");
            int id = Convert.ToInt32(Console.ReadLine());
            BookController controller = new BookController(dbContext, mapper);
            var book = controller.GetBookById(id);
            logger.WriteMessage(true, ConsoleColor.Magenta,      $"{book.Id,-3} - ",
                                            ConsoleColor.Yellow, $"{book.Title,-40} ",
                                            ConsoleColor.White,  $"| {book.Author,-30} | ",
                                            ConsoleColor.White,  $" {book.PublishDate.ToString("yyyy.MM.dd")}  | ");
            logger.WriteMessage(true, ConsoleColor.Red, "\r\nPress a key to exit.");
            Console.ReadKey();
        }
    }
}
