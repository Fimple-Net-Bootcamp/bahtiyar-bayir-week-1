using AutoMapper;
using AutoMapper.Execution;
using fimple_bootcamp_week_1_homework.Application.BookOperations.Commands.CreateBook;
using fimple_bootcamp_week_1_homework.Application.BookOperations.Commands.UpdateBook;
using fimple_bootcamp_week_1_homework.Controllers;
using fimple_bootcamp_week_1_homework.DBOperations;
using fimple_bootcamp_week_1_homework.DTOs.BookDTO;
using fimple_bootcamp_week_1_homework.DTOs.MemberDTO;
using fimple_bootcamp_week_1_homework.Entitys;
using fimple_bootcamp_week_1_homework.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
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
                logger.WriteTitle(ConsoleColor.Green, "Fimple ",
                                      ConsoleColor.Yellow, " Kütüphanesine hoşgediniz!");

                logger.WriteMessage(true, ConsoleColor.White, "\tYapmak istediğiniz işlemi seçin:\r\n",
                                          ConsoleColor.Yellow, "\tKitap ödünç verme/geri alma işlemleri:\r\n",
                                          ConsoleColor.Magenta, "\t\t1  ", ConsoleColor.White, "- Üye kitap ödünç alma kaydı oluştur\r\n",
                                          ConsoleColor.Magenta, "\t\t2  ", ConsoleColor.White, "- Kitap geri alma işlemi\r\n",
                                          ConsoleColor.Magenta, "\t\t3  ", ConsoleColor.White, "- Okuma odalarındaki kitapları geri topla\r\n",
                                          ConsoleColor.Yellow, "\tKitap işlemleri:\r\n",
                                          ConsoleColor.Magenta, "\t\t4  ", ConsoleColor.White, "- Kitap kaydı oluştur\r\n",
                                          ConsoleColor.Magenta, "\t\t5  ", ConsoleColor.White, "- Kitap kaydı sil\r\n",
                                          ConsoleColor.Magenta, "\t\t6  ", ConsoleColor.White, "- Kitap kaydı güncelle\r\n",
                                          ConsoleColor.Magenta, "\t\t7  ", ConsoleColor.White, "- Kayıtlı tüm kitapları listele\r\n",
                                          ConsoleColor.Magenta, "\t\t8  ", ConsoleColor.White, "- Kitap kaydı görüntüle (Kitap başlığına göre)\r\n",
                                          ConsoleColor.Magenta, "\t\t9  ", ConsoleColor.White, "- Ödünç alınabilir kitapları listele\r\n",
                                          ConsoleColor.Magenta, "\t\t10 ", ConsoleColor.White, "- Ödünç alınmış kitapları listele \r\n",
                                          ConsoleColor.Yellow, "\tÜye işlemleri:\r\n",
                                          ConsoleColor.Magenta, "\t\t11 ", ConsoleColor.White, "- Üye kaydı oluştur\r\n",
                                          ConsoleColor.Magenta, "\t\t12 ", ConsoleColor.White, "- Üye kaydı sil\r\n",
                                          ConsoleColor.Magenta, "\t\t13 ", ConsoleColor.White, "- Üye kaydı güncelle\r\n",
                                          ConsoleColor.Magenta, "\t\t14 ", ConsoleColor.White, "- Üye aktif/pasif durumu değiştir\r\n",
                                          ConsoleColor.Magenta, "\t\t15 ", ConsoleColor.White, "- Kayıtlı tüm üyeleri listele\r\n",
                                          ConsoleColor.Magenta, "\t\t16 ", ConsoleColor.White, "- Üye kaydı görüntüle (Üye ID numarasına göre)\r\n",
                                          ConsoleColor.Magenta, "\t\t17 ", ConsoleColor.White, "- Aktif olan üyeleri listele\r\n",
                                          ConsoleColor.Magenta, "\t\t18 ", ConsoleColor.White, "- Pasif olan üyeleri listele\r\n",
                                          ConsoleColor.Magenta, "\t\t19 ", ConsoleColor.White, "- Kitap ödünç almış üyeleri görüntüle\r\n",
                                          ConsoleColor.Yellow, "\tYazar işlemleri:\r\n",
                                          ConsoleColor.Magenta, "\t\t20 ", ConsoleColor.White, "- Yazar kaydı oluştur\r\n",
                                          ConsoleColor.Magenta, "\t\t21 ", ConsoleColor.White, "- Yazar kaydı sil\r\n",
                                          ConsoleColor.Magenta, "\t\t22 ", ConsoleColor.White, "- Yazar kaydı güncelle\r\n",
                                          ConsoleColor.Magenta, "\t\t23 ", ConsoleColor.White, "- Kayıtlı tüm yazarları listele\r\n",
                                          ConsoleColor.Magenta, "\t\t24 ", ConsoleColor.White, "- Yazar kaydı görüntüle (Yazar ID numarasına göre)\r\n",
                                          ConsoleColor.Magenta, "\t\t25 ", ConsoleColor.White, "- Exit\r\n\r\n");
                logger.WriteMessage(false, ConsoleColor.Cyan, "Your choice>");
                switch (Console.ReadLine())
                {
                    /*case "1": CreateBookBorrowingRecord(); break;
                    case "2": ReturnBorrowedBook(); break;
                    case "3": CollectBooksFromReadingRoom(); break;*/
                    case "4": CreateBookRecord(); break;
                    case "5": DeleteBookRecord(); break;
                    case "6": UpdateBookRecord(); break; 
                    case "7": PrintListofAllBooks(); break;
                    case "8": PrintBookByTitle(); break;
                    case "9": PrintOnlyAvailableForBorrowBookList(); break;
                    case "10": PrintOnlyUnavailableForBorrowBookList(); break;
                    case "11": CreateMemberRecord(); break;
                    case "12": DeleteMemberRecord(); break;
                    /*case "13": UpdateMemberRecord(); break;
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
            logger.WriteTitle(ConsoleColor.Blue, "4 - Kitap Kaydı Oluşturma");
            CreateBookModel model = new();
            logger.WriteMessage(true, ConsoleColor.Yellow, "Lütfen istenen bilgileri giriniz:\r\n\n");

            logger.WriteMessage(false, ConsoleColor.White, $"{"Kitap başlığı*:",-30}"); model.Title = Console.ReadLine();
            logger.WriteMessage(false, ConsoleColor.White, $"{"Yazarın ID'si*:",-30}"); model.AuthorId = Convert.ToInt32(Console.ReadLine());
            logger.WriteMessage(false, ConsoleColor.White, $"{"Yayınlanma tarihi*(gg.aa.yyyy):",-30}");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime result)) model.PublishDate = result;
            else { logger.WriteMessage(true, ConsoleColor.White, "Girilen ", ConsoleColor.Red, "tarih", ConsoleColor.White, " formatı hatalı. Kayıt yapılamadı!\r\n"); Console.ReadKey(); return; }
            BookController controller = new(dbContext, mapper, logger);
            if (controller.CreateBook(model) == ProcessStatus.isSuccess)
            {
                logger.WriteMessage(true, ConsoleColor.Green, $"{model.Title}", ConsoleColor.White, " başlıklı kitap başarıyla kaydedildi.");
                Console.ReadKey();
            }
            else
            {
                logger.WriteMessage(true, ConsoleColor.White, "Kitap kaydı yapılamadı!");
                Console.ReadKey();
            }
        }

        /// <summary>
        ///  Function defined for the "5 Delete book record" menu.
        /// </summary>
        internal void DeleteBookRecord()
        {
            Console.Clear();
            logger.WriteTitle(ConsoleColor.Blue, "5 - Kitap Kaydı Silme");
            logger.WriteMessage(true, ConsoleColor.Yellow, "Lütfen kaydını silmek istediğiniz kitabın ID numarasını giriniz:\r\n");
            int id = int.Parse(Console.ReadLine());
            BookController controller = new(dbContext, mapper, logger);
            var book = controller.GetBookById(id);
            if (book is not null)
            {
                logger.WriteMessage(false, ConsoleColor.DarkYellow, "\nUyarı! ", ConsoleColor.Green, $"{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(book.Title)}", ConsoleColor.White, " başlıklı kitabı silmek üzeresiniz onaylıyor musunuz? (Evet: e/E)");
                if (Console.ReadLine().Trim().ToLower() == "e")
                {
                    if (controller.DeleteBook(id) == ProcessStatus.isSuccess)
                    {
                        logger.WriteMessage(true, ConsoleColor.Green, $"\n\n{book.Title}", ConsoleColor.White, " başlıklı kitap kaydı başarıyla silindi.");
                    }
                    else
                    {
                        logger.WriteMessage(true, ConsoleColor.White, "Kitap kaydı yapılamadı!");
                    }
                }
                else logger.WriteMessage(true, ConsoleColor.White, "Kayıt silme işlemi iptal edildi.");
            }
            Console.ReadKey();
        }

        /// <summary>
        ///  Function defined for the "6 Update book record" menu.
        /// </summary>
        internal void UpdateBookRecord()
        {
            Console.Clear();
            logger.WriteTitle(ConsoleColor.Blue, "6 - Kitap Kaydı Güncelleme ");
            logger.WriteMessage(true, ConsoleColor.Yellow, "Lütfen kaydını güncellemek istediğiniz kitabın ID numarasını giriniz:\r\n");
            int id = int.Parse(Console.ReadLine());
            BookController controller = new(dbContext, mapper, logger);
            var book = controller.GetBookById(id);
            if (book is not null)
            {
                UpdateBookModel model = new();
                logger.WriteMessage(true, ConsoleColor.Yellow, "Lütfen istenen bilgileri giriniz:\r\n\n");

                logger.WriteMessage(false, ConsoleColor.White, $"{"Kitap başlığı*:",-30}"); model.Title = Console.ReadLine();
                logger.WriteMessage(false, ConsoleColor.White, $"{"Yazarın ID'si*:",-30}"); model.AuthorId = Convert.ToInt32(Console.ReadLine());
                logger.WriteMessage(false, ConsoleColor.White, $"{"Yayınlanma tarihi*(gg.aa.yyyy):",-30}");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime result)) model.PublishDate = result;
                else { logger.WriteMessage(true, ConsoleColor.White, "Girilen ", ConsoleColor.Red, "tarih", ConsoleColor.White, " formatı hatalı. Kayıt yapılamadı!\r\n"); Console.ReadKey(); return; }
                if (controller.UpdateBook(id, model) == ProcessStatus.isSuccess)
                {
                    logger.WriteMessage(true, ConsoleColor.Green, $"{model.Title}", ConsoleColor.White, " başlıklı kitap başarıyla güncellendi.");
                    Console.ReadKey();
                }
                else
                {
                    logger.WriteMessage(true, ConsoleColor.White, "\nKitap kaydı güncellenemedi!");
                    Console.ReadKey();
                }
            }
            Console.ReadKey();
        }


        /// <summary>
        ///  Function defined for the "7 List all books" menu.
        /// </summary>
        internal void PrintListofAllBooks()
        {
            Console.Clear();
            logger.WriteTitle(ConsoleColor.Blue, "7 - Kayıtlı Kitaplar Listesi ");
            logger.WriteMessage(true, ConsoleColor.DarkCyan, "ID  -               Kitap Başlığı              |              Yazar             | Yayın Tarihi |   Durumu\r\n" + new string('-', 143));
            BookController controller = new BookController(dbContext, mapper, logger);
            var bookList = controller.GetBooks();
            bookList.ForEach(x =>
            {

                logger.WriteMessage(true, ConsoleColor.Magenta, $"{x.Id,-3} - ",
                                            ConsoleColor.Yellow, $"{x.Title,-40}",
                                            ConsoleColor.White, $" | {x.Author,-30} | ",
                                            ConsoleColor.White, $" {x.PublishDate.ToString("yyyy.MM.dd")}  | ",
                                            x.State ? ConsoleColor.Green : ConsoleColor.Red, x.State ? "Alınabilir" : "Alınamaz");
            });

            logger.WriteMessage(true, ConsoleColor.Red, "\r\nPress a key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        ///  Function defined for the "8 Get book by Title" menu.
        /// </summary>
        internal void PrintBookByTitle()
        {
            Console.Clear();
            logger.WriteTitle(ConsoleColor.Blue, " 8 - ID'ye Göre Kitap Kaydı Görüntüleme");
            logger.WriteMessage(true, ConsoleColor.Yellow, "Kaydını görmek istediğiniz kitap ID'sini girin>");
            int id = int.Parse(Console.ReadLine());
            BookController controller = new BookController(dbContext, mapper, logger);
            var book = controller.GetBookById(id);
            if (book is null)
            {
                Console.ReadKey();
                return;
            }
            logger.WriteMessage(true, ConsoleColor.DarkCyan, "ID  -               Kitap Başlığı              |              Yazar             | Yayın Tarihi |   Durumu\r\n" + new string('-', 143));
            logger.WriteMessage(true, ConsoleColor.Magenta, $"{book.Id,-3} - ",
                                            ConsoleColor.Yellow, $"{book.Title,-40} ",
                                            ConsoleColor.White, $"| {book.Author,-30} | ",
                                            ConsoleColor.White, $" {book.PublishDate.ToString("yyyy.MM.dd")}  | ",
                                            book.State ? ConsoleColor.Green : ConsoleColor.Red, book.State ? "Alınabilir" : "Alınamaz"
            );
            logger.WriteMessage(true, ConsoleColor.Red, "\r\nPress a key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        ///  Function defined for the "9 List the books that can be borrowedd" menu.
        /// </summary>
        internal void PrintOnlyAvailableForBorrowBookList()
        {
            Console.Clear();
            logger.WriteTitle(ConsoleColor.Blue, "9 - Alınabilir Kitaplar Listesi");
            logger.WriteMessage(true, ConsoleColor.DarkCyan, "ID  -               Kitap Başlığı              |              Yazar             | Yayın Tarihi |   Durumu\r\n" + new string('-', 143));
            BookController controller = new BookController(dbContext, mapper, logger);
            var bookList = controller.GetOnlyAvailableBooks();
            bookList.ForEach(x =>
            {

                logger.WriteMessage(true, ConsoleColor.Magenta, $"{x.Id,-3} - ",
                                            ConsoleColor.Yellow, $"{x.Title,-40}",
                                            ConsoleColor.White, $" | {x.Author,-30} | ",
                                            ConsoleColor.White, $" {x.PublishDate.ToString("yyyy.MM.dd")}  | ",
                                            x.State ? ConsoleColor.Green : ConsoleColor.Red, x.State ? "Alınabilir" : "Alınamaz");
            });

            logger.WriteMessage(true, ConsoleColor.Red, "\r\nPress a key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        ///  Function defined for the "10  List the books that cannot be borrowedd" menu.
        /// </summary>
        internal void PrintOnlyUnavailableForBorrowBookList()
        {
            Console.Clear();
            logger.WriteTitle(ConsoleColor.Blue, "10 - Alınmış Kitaplar Listesi");
            logger.WriteMessage(true, ConsoleColor.DarkCyan, "ID  -               Kitap Başlığı              |              Yazar             | Yayın Tarihi |   Durumu\r\n" + new string('-', 143));
            BookController controller = new BookController(dbContext, mapper, logger);
            var bookList = controller.GetOnlyUnavailableBooks();
            bookList.ForEach(x =>
            {

                logger.WriteMessage(true, ConsoleColor.Magenta, $"{x.Id,-3} - ",
                                            ConsoleColor.Yellow, $"{x.Title,-40}",
                                            ConsoleColor.White, $" | {x.Author,-30} | ",
                                            ConsoleColor.White, $" {x.PublishDate.ToString("yyyy.MM.dd")}  | ",
                                            x.State ? ConsoleColor.Green : ConsoleColor.Red, x.State ? "Alınabilir" : "Alınamaz");
            });

            logger.WriteMessage(true, ConsoleColor.Red, "\r\nPress a key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        ///  Function defined for the "11 - Creating Member Record" menu.
        /// </summary>
        internal void CreateMemberRecord()
        {
            Console.Clear();
            logger.WriteTitle(ConsoleColor.Blue, "11 - Yeni Üye Kaydı");
            CreateMemberModel model = new();
            logger.WriteMessage(true, ConsoleColor.Yellow, "Please enter the following information:\r\n\n");

            logger.WriteMessage(true, ConsoleColor.White, $"{"Name:",-25}");        model.Name      = Console.ReadLine();
            logger.WriteMessage(true, ConsoleColor.White, $"{"Surname:",-25}");     model.Surname   = Console.ReadLine();
            logger.WriteMessage(true, ConsoleColor.White, $"{"City:",-25}");        model.City      = Console.ReadLine();
            logger.WriteMessage(true, ConsoleColor.White, $"{"Birth Day:",-25}");

            if (DateTime.TryParse(Console.ReadLine(), out DateTime result)) model.BirthDay = result;
            else { logger.WriteMessage(true, ConsoleColor.White, "Girilen ", ConsoleColor.Red, "tarih", ConsoleColor.White, " formatı hatalı. Kayıt yapılamadı!\r\n"); Console.ReadKey(); return; }
            MemberController controller = new(dbContext, mapper, logger);
            if (controller.CreateMember(model) == ProcessStatus.isSuccess)
            {
                logger.WriteMessage(true, ConsoleColor.Green, $"{model.Name + " " + model.Surname}", ConsoleColor.White, " isimli kitap başarıyla kaydedildi.");
                Console.ReadKey();
            }
            else
            {
                logger.WriteMessage(true, ConsoleColor.White, "Üye kaydı yapılamadı!");
                Console.ReadKey();
            }
        }
    }
}
