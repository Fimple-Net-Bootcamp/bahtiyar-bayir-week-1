using AutoMapper;
using fimple_bootcamp_week_1_homework.Controllers;
using fimple_bootcamp_week_1_homework.DBOperations;
using fimple_bootcamp_week_1_homework.DTOs.AuthorDTO;
using fimple_bootcamp_week_1_homework.DTOs.BookDTO;
using fimple_bootcamp_week_1_homework.DTOs.BorrowingRecordDTO;
using fimple_bootcamp_week_1_homework.DTOs.MemberDTO;
using fimple_bootcamp_week_1_homework.Entitys;
using fimple_bootcamp_week_1_homework.Services;
using System.Globalization;

namespace fimple_bootcamp_week_1_homework.Manager
{
    internal class Manager : IManager
    {
        private readonly ILibraryDbContext dbContext;
        private readonly ICustomisedMessagePrinter logger;
        private readonly IMapper mapper;
        private readonly int MaxBookCount = 10;

        public Manager(ILibraryDbContext dbContext, ICustomisedMessagePrinter logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;
            Console.WriteLine($"{dbContext.Authors.Count()},{dbContext.Books.Count()}, {dbContext.Members.Count()}, {dbContext.Borrowings.Count()}");
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
                                          ConsoleColor.Magenta, "\t\t3 ", ConsoleColor.White, " - Kitap ödünç almış üyeleri görüntüle\r\n",
                                          ConsoleColor.Yellow, "\tKitap işlemleri:\r\n",
                                          ConsoleColor.Magenta, "\t\t4  ", ConsoleColor.White, "- Kitap kaydı oluştur\r\n",
                                          ConsoleColor.Magenta, "\t\t5  ", ConsoleColor.White, "- Kitap kaydı sil\r\n",
                                          ConsoleColor.Magenta, "\t\t6  ", ConsoleColor.White, "- Kitap kaydı güncelle\r\n",
                                          ConsoleColor.Magenta, "\t\t7  ", ConsoleColor.White, "- Kayıtlı tüm kitapları listele\r\n",
                                          ConsoleColor.Magenta, "\t\t8  ", ConsoleColor.White, "- Kitap kaydı görüntüle (Kitap başlığına göre)\r\n",
                                          ConsoleColor.Magenta, "\t\t9  ", ConsoleColor.White,"- Ödünç alınabilir kitapları listele\r\n",
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
                                          ConsoleColor.Yellow, "\tYazar işlemleri:\r\n",
                                          ConsoleColor.Magenta, "\t\t19 ", ConsoleColor.White, "- Yazar kaydı oluştur\r\n",
                                          ConsoleColor.Magenta, "\t\t20 ", ConsoleColor.White, "- Yazar kaydı sil\r\n",
                                          ConsoleColor.Magenta, "\t\t21 ", ConsoleColor.White, "- Yazar kaydı güncelle\r\n",
                                          ConsoleColor.Magenta, "\t\t22 ", ConsoleColor.White, "- Kayıtlı tüm yazarları listele\r\n",
                                          ConsoleColor.Magenta, "\t\t23 ", ConsoleColor.White, "- Yazar kaydı görüntüle (Yazar ID numarasına göre)\r\n",
                                          ConsoleColor.Magenta, "\t\t24 ", ConsoleColor.White, "- Exit\r\n\r\n");
                logger.WriteMessage(false, ConsoleColor.Cyan, "Your choice>");
                switch (Console.ReadLine())
                {
					case "1":  CreateBookBorrowingRecord(); 			break;
                    case "2":  ReturnBorrowedBook(); 					break;
					case "3":  PrintListofAllBorrowingRecords();		break;
                    case "4":  CreateBookRecord(); 						break;
                    case "5":  DeleteBookRecord(); 						break;
                    case "6":  UpdateBookRecord(); 						break;
                    case "7":  PrintListofAllBooks(); 					break;
					case "8":  PrintBookById(); 						break; 
                    case "9":  PrintOnlyAvailableForBorrowBookList(); 	break;
                    case "10": PrintOnlyUnavailableForBorrowBookList(); break;
                    case "11": CreateMemberRecord(); 					break;
                    case "12": DeleteMemberRecord(); 					break;
                    case "13": UpdateMemberRecord(); 					break;
                    case "14": ChangeMemberStatus(); 					break;
                    case "15": PrintAllMemberList(); 					break;
					case "16": PrintMemberById(); 						break; 
                    case "17": PrintOnlyActiveMemberList(); 			break;
                    case "18": PrintOnlyPassiveMemberList(); 			break;
                    case "19": CreateAuthorRecord(); 					break;
                    case "20": DeleteAuthorRecord(); 					break;
                    case "21": UpdateAuthorRecord(); 					break;
                    case "22": PrintAllAuthorList(); 					break;
					case "23": PrintAuthorById(); 						break; 
                    case "24": loop = false;                            break;
                }
            }
        }

        /// <summary>
        /// Function defined for the "1 Member borrowing book registration process" menu.
        /// </summary>
        internal void CreateBookBorrowingRecord()
        {
            Console.Clear();
            BorrowingController controller = new BorrowingController(dbContext, mapper, logger);
            BookController BookCtrl = new(dbContext, mapper, logger);
            CreateBorrowingRecordModel model = new();

            logger.WriteTitle(ConsoleColor.Blue, "1 - Ödünç Alma Kaydı");
            logger.WriteMessage(false, ConsoleColor.Yellow, "Ödünç alınacak kitap ID'sini girin>");
            model.BookId = int.Parse(Console.ReadLine());
            logger.WriteMessage(false, ConsoleColor.White, "\n\nÜye numarasını girin (Bir üye en fazla 10 kitap alabilir!)>");
            model.MemberId = int.Parse(Console.ReadLine());

            var book = BookCtrl.GetBookById(model.BookId);
            int memberBookCount = controller.GetNumberOfBooksBorrowingByTheUser(model.MemberId);
            if (memberBookCount < MaxBookCount && book.State == true)
            {
                if (controller.CreateBorrowingRecords(model) == ProcessStatus.isSuccess)
                {
                    BookCtrl.UpdateBookState(model.BookId);
                    logger.WriteMessage(true, ConsoleColor.Green, "Ödünç alma kaydı başarılı");
                }
            }
            else
            {
                if(memberBookCount >= MaxBookCount)   logger.WriteMessage(true, ConsoleColor.White, "Bu üye hali hazırda ", ConsoleColor.Red, memberBookCount, ConsoleColor.White, " adet kitap ödünç almış!");
                else if(!book.State) logger.WriteMessage(true, ConsoleColor.Red, book.Title, ConsoleColor.White, " isimli kitap hali hazırda başka bir üye/okuma odası tarafında alınmış!");
            }
            Console.ReadKey();
        }

        internal void ReturnBorrowedBook()
        {
            Console.Clear();
            logger.WriteTitle(ConsoleColor.Blue, "2 - Kitap Geri Alma");
            logger.WriteMessage(false, ConsoleColor.Yellow, "Teslim edilecek kitap ID'sini girin>");
            int id = int.Parse(Console.ReadLine());
            BorrowingController controller = new BorrowingController(dbContext, mapper, logger);
            if(controller.UpdateBorrowingState(id) == ProcessStatus.isSuccess)
            {
                BookController BookCtrl = new(dbContext,mapper, logger);
                BookCtrl.UpdateBookState(id);
                logger.WriteMessage(true, ConsoleColor.Green, "\nKitap başarıyla geri alındı.");
            }
            Console.ReadKey();
        }

        /// <summary>
        ///  Function defined for the "4 List all books" menu.
        /// </summary>
        internal void PrintListofAllBorrowingRecords()
        {
            Console.Clear();
            logger.WriteTitle(ConsoleColor.Blue, "4 - Ödünç Alma Kayıtları");
            BorrowingController controller = new BorrowingController(dbContext, mapper, logger);
            logger.WriteMessage(true, ConsoleColor.Cyan, "No  | BID -    Kitap Başlığı                         | MID -   Üye Adı Soyadı                         | İşlem Tarihi | Teslim Durumu\r\n" + new string('-', 143));
            var records = controller.GetBorrowingRecords();
            records.ForEach(x =>
            {

                logger.WriteMessage(true, ConsoleColor.Magenta, $"{x.Id,-3}", ConsoleColor.White, " | ",
                                            ConsoleColor.DarkYellow, $"{x.BookId,3}", ConsoleColor.White, " - ",
                                            ConsoleColor.Yellow, $"{x.BookTitle,-40}", ConsoleColor.White, " | ",
                                            ConsoleColor.DarkYellow, $"{x.MemberId,3}", ConsoleColor.White, " - ",
                                            ConsoleColor.Yellow, $"{x.MemberNameSurname, -40}", ConsoleColor.White, " | ",
                                            ConsoleColor.White, $"{x.ProcessDate.ToString("yyyy.MM.dd"), 11}", ConsoleColor.White, "  | ",
                                            x.state ? ConsoleColor.Green : ConsoleColor.Red, x.state ? "Teslim Edildi" : "Teslim Edilmedi");
            });

            logger.WriteMessage(true, ConsoleColor.Red, "\r\nPress a key to exit.");
            Console.ReadKey();

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
                        logger.WriteMessage(true, ConsoleColor.White, "Kitap kaydı silme işlemi başarısız oldu!");
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
        internal void PrintBookById()
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
            logger.WriteMessage(true, ConsoleColor.Yellow, "Lütfen istenen bilgileri giriniz:\r\n\n");
            logger.WriteMessage(false, ConsoleColor.White, $"{"Adı:",-40}"); model.Name = Console.ReadLine();
            logger.WriteMessage(false, ConsoleColor.White, $"{"Soyadı:",-40}"); model.Surname = Console.ReadLine();
            logger.WriteMessage(false, ConsoleColor.White, $"{"Memleketi:",-40}"); model.City = Console.ReadLine();
            logger.WriteMessage(false, ConsoleColor.White, $"{"Doğum Tarihi*(gg.aa.yyyy):",-40}");

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

        /// <summary>
        ///  Function defined for the "12 - Delete Member Record" menu.
        /// </summary>
        internal void DeleteMemberRecord()
        {
            Console.Clear();
            logger.WriteTitle(ConsoleColor.Blue, "12 - Üye Kaydı Silme");
            logger.WriteMessage(true, ConsoleColor.Yellow, "Lütfen kaydını silmek istediğiniz üyenin ID numarasını giriniz:\r\n");
            int id = int.Parse(Console.ReadLine());
            MemberController controller = new(dbContext, mapper, logger);
            var member = controller.GetMemberById(id);
            if (member is not null)
            {
                logger.WriteMessage(false, ConsoleColor.DarkYellow, "\nUyarı! ", ConsoleColor.Green, $"{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(member.Name + " " + member.Surname)}", ConsoleColor.White, " isimli üyeyi silmek üzeresiniz onaylıyor musunuz? (Evet: e/E)");
                if (Console.ReadLine().Trim().ToLower() == "e")
                {
                    if (controller.DeleteMember(id) == ProcessStatus.isSuccess)
                    {
                        logger.WriteMessage(true, ConsoleColor.Green, $"\n\n{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(member.Name + " " + member.Surname)}", ConsoleColor.White, " isimli üye kaydı başarıyla silindi.");
                    }
                    else
                    {
                        logger.WriteMessage(true, ConsoleColor.White, "Üye kaydı silme işlemi başarısız oldu!");
                    }
                }
                else logger.WriteMessage(true, ConsoleColor.White, "Kayıt silme işlemi iptal edildi.");
            }
            Console.ReadKey();
        }

        /// <summary>
        ///  Function defined for the "12 Update member registration" menu.
        /// </summary>
        internal void UpdateMemberRecord()
        {
            Console.Clear();
            logger.WriteTitle(ConsoleColor.Blue, "13 - Kitap Kaydı Güncelleme ");
            logger.WriteMessage(true, ConsoleColor.Yellow, "Lütfen kaydını güncellemek istediğiniz üyenin ID numarasını giriniz:\r\n");
            int id = int.Parse(Console.ReadLine());
            MemberController controller = new(dbContext, mapper, logger);
            var member = controller.GetMemberById(id);
            if (member is not null)
            {
                UpdateMemberModel model = new();
                logger.WriteMessage(true, ConsoleColor.Yellow, "Lütfen istenen bilgileri giriniz:\r\n\n");
                logger.WriteMessage(false, ConsoleColor.White, $"{"Adı:",-40}");            model.Name = Console.ReadLine();
                logger.WriteMessage(false, ConsoleColor.White, $"{"Soyadı:",-40}");         model.Surname = Console.ReadLine();
                logger.WriteMessage(false, ConsoleColor.White, $"{"Memleketi:",-40}");            model.City = Console.ReadLine();
                logger.WriteMessage(false, ConsoleColor.White, $"{"Doğum Tarihi*(gg.aa.yyyy):",-40}");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime result)) model.BirthDay = result;
                else { logger.WriteMessage(true, ConsoleColor.White, "Girilen ", ConsoleColor.Red, "tarih", ConsoleColor.White, " formatı hatalı. Kayıt yapılamadı!\r\n"); Console.ReadKey(); return; }
                if (controller.UpdateMember(id, model) == ProcessStatus.isSuccess)
                {
                    logger.WriteMessage(true, ConsoleColor.Green, $"{model.Name + " " + model.Surname}", ConsoleColor.White, " isimli üye başarıyla güncellendi.");
                }
                else
                {
                    logger.WriteMessage(true, ConsoleColor.White, "\nKitap kaydı güncellenemedi!");
                }
            }
            Console.ReadKey();
        }

        /// <summary>
        ///  Function defined for the "14 change member status" menu.
        /// </summary>
        internal void ChangeMemberStatus()
        {
            Console.Clear();
            logger.WriteTitle(ConsoleColor.Blue, "14 - Üye Aktif/Pasif Durum Değiştirmesi");
            logger.WriteMessage(true, ConsoleColor.Yellow, "Lütfen durmunu güncellemek istediğiniz üyenin ID numarasını giriniz:\r\n");
            int id = int.Parse(Console.ReadLine());
            MemberController controller = new(dbContext, mapper, logger);
            var member = controller.GetMemberById(id);
            if (member is not null)
            {
                logger.WriteMessage(false, ConsoleColor.DarkYellow, "\nUyarı! ", ConsoleColor.Green, $"{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(member.Name + " " + member.Surname)}", ConsoleColor.White, " isimli üyeyin durumunu ", member.State ? ConsoleColor.Red : ConsoleColor.Green, member.State ? "Pasif" : "Aktif", ConsoleColor.White, " üzeresiniz onaylıyor musunuz? (Evet: e/E)");
                if (Console.ReadLine().Trim().ToLower() == "e")
                {
                    if (controller.UpdateMemberStatus(id) == ProcessStatus.isSuccess)
                    {
                        logger.WriteMessage(true, ConsoleColor.Green, $"\n\n{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(member.Name + " " + member.Surname)}", ConsoleColor.White, " isimli üyenin durumu başarıyla güncellendi.");
                    }
                    else
                    {
                        logger.WriteMessage(true, ConsoleColor.White, "Üye durum güncellemesi başarısız oldu!");
                    }
                }
                else logger.WriteMessage(true, ConsoleColor.White, "Üye durum güncelleme işlemi iptal edildi.");
            }
            Console.ReadKey();
        }

        /// <summary>
        ///  Function defined for the "7 List all books" menu.
        /// </summary>
        internal void PrintAllMemberList()
        {
            Console.Clear();
            logger.WriteTitle(ConsoleColor.Blue, "15 - Kayıtlı Üyeler Listesi ");
            logger.WriteMessage(true, ConsoleColor.DarkCyan, "ID  -     Üye Adı Soyadı                             |         Şehir         |  Doğum Günü  | Ak/Pas  |        Aldığı Kitap Sayısı\r\n" + new string('-', 143));
            MemberController controller = new MemberController(dbContext, mapper, logger);
            BorrowingController BCtrl = new BorrowingController(dbContext, mapper, logger);
            var memberList = controller.GetMembers();
            memberList.ForEach(x =>
            {

                logger.WriteMessage(true, ConsoleColor.Magenta, $"{x.Id,-3} - ",
                                            ConsoleColor.Yellow, $"{x.Name + " " + x.Surname,-46}",
                                            ConsoleColor.White, $" | {x.City, -21} | ",
                                            ConsoleColor.White, $" {x.BirthDay.ToString("yyyy.MM.dd")}  | ",
                                            x.State ? ConsoleColor.Green : ConsoleColor.Red, x.State? $"{"Aktif",-7}": $"{"Pasif",-7}", ConsoleColor.White, " | ", 
                                            ConsoleColor.White, "Üye ", ConsoleColor.DarkBlue, BCtrl.GetNumberOfBooksBorrowingByTheUser(x.Id), ConsoleColor.White, " tane kitap ödünç almış.");
            });

            logger.WriteMessage(true, ConsoleColor.Red, "\r\nPress a key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        ///  Function defined for the "8 Get book by Title" menu.
        /// </summary>
        internal void PrintMemberById()
        {
            Console.Clear();
            logger.WriteTitle(ConsoleColor.Blue, " 16 - ID'ye Göre Üye Kaydı Görüntüleme");
            logger.WriteMessage(true, ConsoleColor.Yellow, "Kaydını görmek istediğiniz üye ID'sini girin>");
            int id = int.Parse(Console.ReadLine());
            MemberController controller = new MemberController(dbContext, mapper, logger);
            BorrowingController BCtrl = new BorrowingController(dbContext, mapper, logger);
            var member = controller.GetMemberById(id);
            if (member is null)
            {
                Console.ReadKey();
                return;
            }
            logger.WriteMessage(true, ConsoleColor.DarkCyan, "ID  -     Üye Adı Soyadı                             |         Şehir         |  Doğum Günü  | Ak/Pas  |        Aldığı Kitap Sayısı\r\n" + new string('-', 143));
            logger.WriteMessage(true, ConsoleColor.Magenta, $"{member.Id,-3} - ",
                                            ConsoleColor.Yellow, $"{member.Name + " " + member.Surname,-46}",
                                            ConsoleColor.White, $" | {member.City,-21} | ",
                                            ConsoleColor.White, $" {member.BirthDay.ToString("yyyy.MM.dd")}  | ",
                                            member.State ? ConsoleColor.Green : ConsoleColor.Red, member.State ? $"{"Aktif",-7}" : $"{"Pasif",-7}", ConsoleColor.White, " | ",
                                            ConsoleColor.White, "Üye ", ConsoleColor.DarkBlue, BCtrl.GetNumberOfBooksBorrowingByTheUser(member.Id), ConsoleColor.White, " tane kitap ödünç almış.");
            logger.WriteMessage(true, ConsoleColor.Red, "\r\nPress a key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        ///  Function defined for the "9 List the active member" menu.
        /// </summary>
        internal void PrintOnlyActiveMemberList()
        {
            Console.Clear();
            logger.WriteTitle(ConsoleColor.Blue, "17 - Kayıtlı Aktif Üyeler Listesi ");
            logger.WriteMessage(true, ConsoleColor.DarkCyan, "ID  -     Üye Adı Soyadı                             |         Şehir         |  Doğum Günü  | Ak/Pas  |        Aldığı Kitap Sayısı\r\n" + new string('-', 143));
            MemberController controller = new MemberController(dbContext, mapper, logger);
            BorrowingController BCtrl = new BorrowingController(dbContext, mapper, logger);
            var memberList = controller.GetOnlyActiveMembers();
            memberList.ForEach(x =>
            {

                logger.WriteMessage(true, ConsoleColor.Magenta, $"{x.Id,-3} - ",
                                            ConsoleColor.Yellow, $"{x.Name + " " + x.Surname,-46}",
                                            ConsoleColor.White, $" | {x.City,-21} | ",
                                            ConsoleColor.White, $" {x.BirthDay.ToString("yyyy.MM.dd")}  | ",
                                            x.State ? ConsoleColor.Green : ConsoleColor.Red, x.State ? $"{"Aktif",-7}" : $"{"Pasif",-7}", ConsoleColor.White, " | ",
                                            ConsoleColor.White, "Üye ", ConsoleColor.DarkBlue, BCtrl.GetNumberOfBooksBorrowingByTheUser(x.Id), ConsoleColor.White, " tane kitap ödünç almış.");
            });

            logger.WriteMessage(true, ConsoleColor.Red, "\r\nPress a key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        ///  Function defined for the "18  List the passive member" menu.
        /// </summary>
        internal void PrintOnlyPassiveMemberList()
        {
            Console.Clear();
            logger.WriteTitle(ConsoleColor.Blue, "18 - Kayıtlı Pasif Üyeler Listesi ");
            logger.WriteMessage(true, ConsoleColor.DarkCyan, "ID  -     Üye Adı Soyadı                             |         Şehir         |  Doğum Günü  | Ak/Pas\r\n" + new string('-', 143));
            MemberController controller = new MemberController(dbContext, mapper, logger);
            var memberList = controller.GetOnlyInactiveMembers();
            memberList.ForEach(x =>
            {
                logger.WriteMessage(true, ConsoleColor.Magenta, $"{x.Id,-3} - ",
                                            ConsoleColor.Yellow, $"{x.Name + " " + x.Surname,-46}",
                                            ConsoleColor.White, $" | {x.City,-21} | ",
                                            ConsoleColor.White, $" {x.BirthDay.ToString("yyyy.MM.dd")}  | ",
                                            x.State ? ConsoleColor.Green : ConsoleColor.Red, x.State ? $"{"Aktif",-7}" : $"{"Pasif",-7}", ConsoleColor.White, " | "
                                            /*ConsoleColor.White, "He/She borrowed ", ConsoleColor.DarkBlue, m.BorrowedBooks.Count, ConsoleColor.White, " number of books.""*/);
            });

            logger.WriteMessage(true, ConsoleColor.Red, "\r\nPress a key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        ///  Function defined for the "20 - Creating Author Record" menu.
        /// </summary>
        internal void CreateAuthorRecord()
        {
            Console.Clear();
            logger.WriteTitle(ConsoleColor.Blue, "20 - Yeni Yazar Kaydı");
            CreateAuthorModel model = new();
            logger.WriteMessage(true, ConsoleColor.Yellow, "Lütfen istenen bilgileri giriniz:\r\n\n");
            logger.WriteMessage(false, ConsoleColor.White, $"{"Adı:",-40}"); model.Name = Console.ReadLine();
            logger.WriteMessage(false, ConsoleColor.White, $"{"Soyadı:",-40}"); model.Surname = Console.ReadLine();

            AuthorController controller = new(dbContext, mapper, logger);
            if (controller.CreateAuthor(model) == ProcessStatus.isSuccess)
            {
                logger.WriteMessage(true, ConsoleColor.Green, $"{model.Name + " " + model.Surname}", ConsoleColor.White, " isimli kitap başarıyla kaydedildi.");
                Console.ReadKey();
            }
            else
            {
                logger.WriteMessage(true, ConsoleColor.White, "yazar kaydı yapılamadı!");
                Console.ReadKey();
            }
        }

        /// <summary>
        ///  Function defined for the "21 - Delete Author Record" menu.
        /// </summary>
        internal void DeleteAuthorRecord()
        {
            Console.Clear();
            logger.WriteTitle(ConsoleColor.Blue, "21 - Yazar Kaydı Silme");
            logger.WriteMessage(true, ConsoleColor.Yellow, "Lütfen kaydını silmek istediğiniz yazarnin ID numarasını giriniz:\r\n");
            int id = int.Parse(Console.ReadLine());
            AuthorController controller = new(dbContext, mapper, logger);
            var Author = controller.GetAuthorById(id);
            if (Author is not null)
            {
                logger.WriteMessage(false, ConsoleColor.DarkYellow, "\nUyarı! ", ConsoleColor.Green, $"{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Author.Name + " " + Author.Surname)}", ConsoleColor.White, " isimli yazaryi silmek üzeresiniz onaylıyor musunuz? (Evet: e/E)");
                if (Console.ReadLine().Trim().ToLower() == "e")
                {
                    if (controller.DeleteAuthor(id) == ProcessStatus.isSuccess)
                    {
                        logger.WriteMessage(true, ConsoleColor.Green, $"\n\n{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Author.Name + " " + Author.Surname)}", ConsoleColor.White, " isimli yazar kaydı başarıyla silindi.");
                    }
                    else
                    {
                        logger.WriteMessage(true, ConsoleColor.White, "yazar kaydı silme işlemi başarısız oldu!");
                    }
                }
                else logger.WriteMessage(true, ConsoleColor.White, "Kayıt silme işlemi iptal edildi.");
            }
            Console.ReadKey();
        }

        /// <summary>
        ///  Function defined for the "22 Update Author registration" menu.
        /// </summary>
        internal void UpdateAuthorRecord()
        {
            Console.Clear();
            logger.WriteTitle(ConsoleColor.Blue, "22 - Yazar Kaydı Güncelleme ");
            logger.WriteMessage(true, ConsoleColor.Yellow, "Lütfen kaydını güncellemek istediğiniz yazarnin ID numarasını giriniz:\r\n");
            int id = int.Parse(Console.ReadLine());
            AuthorController controller = new(dbContext, mapper, logger);
            var Author = controller.GetAuthorById(id);
            if (Author is not null)
            {
                UpdateAuthorModel model = new();
                logger.WriteMessage(true, ConsoleColor.Yellow, "Lütfen istenen bilgileri giriniz:\r\n\n");
                logger.WriteMessage(false, ConsoleColor.White, $"{"Adı:",-40}"); model.Name = Console.ReadLine();
                logger.WriteMessage(false, ConsoleColor.White, $"{"Soyadı:",-40}"); model.Surname = Console.ReadLine();
                if (controller.UpdateAuthor(id, model) == ProcessStatus.isSuccess)
                {
                    logger.WriteMessage(true, ConsoleColor.Green, $"{model.Name + " " + model.Surname}", ConsoleColor.White, " isimli yazar başarıyla güncellendi.");
                }
                else
                {
                    logger.WriteMessage(true, ConsoleColor.White, "\nKitap kaydı güncellenemedi!");
                }
            }
            Console.ReadKey();
        }

        /// <summary>
        ///  Function defined for the "23 List all authors" menu.
        /// </summary>
        internal void PrintAllAuthorList()
        {
            Console.Clear();
            logger.WriteTitle(ConsoleColor.Blue, "23 - Kayıtlı Yazarler Listesi ");
            logger.WriteMessage(true, ConsoleColor.DarkCyan, "MID -        Yazar Adı Soyadı                                              | Yazdığı Kitap Sayısı\r\n" + new string('-', 143)); 
            AuthorController controller = new AuthorController(dbContext, mapper, logger);
            var AuthorList = controller.GetAuthors();
            AuthorList.ForEach(x =>
            {

                logger.WriteMessage(true, ConsoleColor.Magenta, $"{x.Id,-3}", ConsoleColor.White, " - ",
                                        ConsoleColor.Yellow, $"{x.Name + " " + x.Surname,-68}", ConsoleColor.White, " | ",
                                            ConsoleColor.White, "Yazarın toplam ", ConsoleColor.DarkCyan, controller.GetBookCount(x.Id), ConsoleColor.White, " tane kitabı bulunmaktadır."

                                            );
            });

            logger.WriteMessage(true, ConsoleColor.Red, "\r\nPress a key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        ///  Function defined for the "24 Get Author by Title" menu.
        /// </summary>
        internal void PrintAuthorById()
        {
            Console.Clear();
            logger.WriteTitle(ConsoleColor.Blue, " 24 - ID'ye Göre Yazar Kaydı Görüntüleme");
            logger.WriteMessage(true, ConsoleColor.Yellow, "Kaydını görmek istediğiniz yazar ID'sini girin>");
            int id = int.Parse(Console.ReadLine());
            AuthorController controller = new AuthorController(dbContext, mapper, logger);
            var Author = controller.GetAuthorById(id);
            if (Author is null)
            {
                Console.ReadKey();
                return;
            }
            logger.WriteMessage(true, ConsoleColor.DarkCyan, "MID -        Yazar Adı Soyadı                                              | Yazdığı Kitap Sayısı\r\n" + new string('-', 143));

            logger.WriteMessage(true, ConsoleColor.Magenta, $"{Author.Id,-3}",ConsoleColor.White, " - ",
                                        ConsoleColor.Yellow, $"{Author.Name + " " + Author.Surname,-68}", ConsoleColor.White, " | ",
                                        ConsoleColor.White, "Yazarın toplam ", ConsoleColor.DarkCyan, controller.GetBookCount(Author.Id), ConsoleColor.White, " tane kitabı bulunmaktadır."
                                        );
            logger.WriteMessage(true, ConsoleColor.Red, "\r\nPress a key to exit.");
            Console.ReadKey();
        }
    }
}
