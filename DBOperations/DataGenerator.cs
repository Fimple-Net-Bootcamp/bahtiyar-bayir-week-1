using fimple_bootcamp_week_1_homework.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.DBOperations
{
    internal class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibraryDbContext(serviceProvider.GetRequiredService<DbContextOptions<LibraryDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                context.Authors.AddRange(
                    #region Author Data
                    new Author{ Name = "Hallsy", Surname = "Bodill", },
                    new Author{ Name = "Demetrius", Surname = "Winslade", },
                    new Author{ Name = "Maddy", Surname = "Fockes", },
                    new Author{ Name = "Ruggiero", Surname = "Bruyet", },
                    new Author{ Name = "Karoly", Surname = "Faiers", },
                    new Author{ Name = "Lissie", Surname = "Coldwell", },
                    new Author{ Name = "Emmit", Surname = "Lethibridge" },
                    new Author{ Name = "Mandel", Surname = "Di Biasio", },
                    new Author{ Name = "Claudine", Surname = "Gyurkovics", },
                    new Author{ Name = "Sergent", Surname = "Pashby", },
                    new Author{ Name = "Quintilla", Surname = "Crosscombe", },
                    new Author{ Name = "Roseline", Surname = "Tilbrook", },
                    new Author{ Name = "Ema", Surname = "Angus", },
                    new Author{ Name = "Heloise", Surname = "Pawling", },
                    new Author{ Name = "Minetta", Surname = "Desport", },
                    new Author{ Name = "Bev", Surname = "Barg", },
                    new Author{ Name = "Ianthe", Surname = "Sprowles", },
                    new Author{ Name = "Robin", Surname = "Cinderey", },
                    new Author{ Name = "Antoinette", Surname = "Aucott", },
                    new Author{ Name = "Jard", Surname = "Cooch", },
                    new Author{ Name = "Mariel", Surname = "Snelgar", },
                    new Author{ Name = "Eldredge", Surname = "Lillyman", },
                    new Author{ Name = "Angelique", Surname = "Bohey", },
                    new Author{ Name = "Billye", Surname = "Kubyszek", },
                    new Author{ Name = "Averyl", Surname = "Dechelette", },
                    new Author{ Name = "Malissia", Surname = "Izhakov", },
                    new Author{ Name = "Bernarr", Surname = "Hathwood", },
                    new Author{ Name = "Lorena", Surname = "Puckring", },
                    new Author{ Name = "Niel", Surname = "Langley", },
                    new Author{ Name = "Roderic", Surname = "Tomaschke", }
                    #endregion
                );
                context.Books.AddRange(
                    #region Book Data
                    new Book{Title = "Beverly Hills Cop III",                       AuthorId = 1,     PublishDate = new DateTime(1919, 01, 26)},
                    new Book{Title = "Alila",                                       AuthorId = 8,     PublishDate = new DateTime(1924, 09, 13)},
                    new Book{Title = "Fawlty Towers (1975-1979)",                   AuthorId = 30,    PublishDate = new DateTime(1904, 10, 11)},
                    new Book{Title = "Muddy River",                                 AuthorId = 2,     PublishDate = new DateTime(1970, 09, 26)},
                    new Book{Title = "Hit Lady",                                    AuthorId = 3,     PublishDate = new DateTime(1922, 09, 04)},
                    new Book{Title = "Dragonheart",                                 AuthorId = 4,     PublishDate = new DateTime(1957, 07, 14)},
                    new Book{Title = "Feeling Minnesota",                           AuthorId = 17,    PublishDate = new DateTime(1916, 10, 23)},
                    new Book{Title = "Me and the Colonel",                          AuthorId = 1,     PublishDate = new DateTime(1909, 03, 09)},
                    new Book{Title = "Odd Couple II, The",                          AuthorId = 7,     PublishDate = new DateTime(1995, 04, 01)},
                    new Book{Title = "End of Summer",                               AuthorId = 26,    PublishDate = new DateTime(1928, 09, 14)},
                    new Book{Title = "My First Mister",                             AuthorId = 18,    PublishDate = new DateTime(1924, 02, 18)},
                    new Book{Title = "Hideaway",                                    AuthorId = 25,    PublishDate = new DateTime(1999, 02, 17)},
                    new Book{Title = "Left Behind II: Tribulation Force",           AuthorId = 6,     PublishDate = new DateTime(1933, 05, 22)},
                    new Book{Title = "Heart Is a Lonely Hunter, The",               AuthorId = 4,     PublishDate = new DateTime(1994, 12, 11)},
                    new Book{Title = "In Bloom (Grzeli nateli dgeebi)",             AuthorId = 29,    PublishDate = new DateTime(1983, 02, 09)},
                    new Book{Title = "Guardian, The",                               AuthorId = 11,    PublishDate = new DateTime(1920, 03, 24)},
                    new Book{Title = "Kissed",                                      AuthorId = 5,     PublishDate = new DateTime(1924, 07, 05)},
                    new Book{Title = "Jupiter's Darling",                           AuthorId = 15,    PublishDate = new DateTime(1997, 08, 25)},
                    new Book{Title = "Langoliers, The",                             AuthorId = 14,    PublishDate = new DateTime(1983, 09, 07)},
                    new Book{Title = "Master of the Flying Guillotine ",            AuthorId = 19,    PublishDate = new DateTime(1998, 03, 21)},
                    new Book{Title = "Cinderella Man",                              AuthorId = 2,     PublishDate = new DateTime(1916, 11, 10)},
                    new Book{Title = "After the Fox (Caccia alla volpe)",           AuthorId = 4,     PublishDate = new DateTime(1903, 02, 07)},
                    new Book{Title = "Three Stooges, The",                          AuthorId = 13,    PublishDate = new DateTime(1971, 07, 19)},
                    new Book{Title = "Go-Getter, The",                              AuthorId = 30,    PublishDate = new DateTime(1934, 10, 13)},
                    new Book{Title = "Bloody New Year",                             AuthorId = 9,     PublishDate = new DateTime(1912, 10, 10)},
                    new Book{Title = "Egg and I, The",                              AuthorId = 1,     PublishDate = new DateTime(1929, 08, 24)},
                    new Book{Title = "Family United ",                              AuthorId = 23,    PublishDate = new DateTime(1926, 05, 27)},
                    new Book{Title = "Fury",                                        AuthorId = 11,    PublishDate = new DateTime(1968, 07, 30)},
                    new Book{Title = "Girl, The",                                   AuthorId = 25,    PublishDate = new DateTime(1998, 08, 22)},
                    new Book{Title = "Russian Specialist, The",                     AuthorId = 26,    PublishDate = new DateTime(1901, 08, 28)},
                    new Book{Title = "My Beautiful Dacia",                          AuthorId = 13,    PublishDate = new DateTime(1958, 11, 01)},
                    new Book{Title = "Man, Woman and Beast",                        AuthorId = 8,     PublishDate = new DateTime(1919, 02, 13)},
                    new Book{Title = "Polish Wedding",                              AuthorId = 2,     PublishDate = new DateTime(1975, 03, 03)},
                    new Book{Title = "Merlusse",                                    AuthorId = 5,     PublishDate = new DateTime(1948, 06, 05)},
                    new Book{Title = "Farewell to the King",                        AuthorId = 20,    PublishDate = new DateTime(1910, 02, 19)},
                    new Book{Title = "Carry On... Up the Khyber",                   AuthorId = 16,    PublishDate = new DateTime(1921, 06, 18)},
                    new Book{Title = "Dorian Blues",                                AuthorId = 24,    PublishDate = new DateTime(1967, 07, 05)},
                    new Book{Title = "Desi Boyz",                                   AuthorId = 23,    PublishDate = new DateTime(1925, 05, 20)},
                    new Book{Title = "Pan's Labyrinth",                             AuthorId = 25,    PublishDate = new DateTime(1902, 05, 26)},
                    new Book{Title = "Island of Dr. Moreau, The",                   AuthorId = 9,     PublishDate = new DateTime(1992, 05, 29)},
                    new Book{Title = "Eleventh Year, The ",                         AuthorId = 4,     PublishDate = new DateTime(1951, 11, 10)},
                    new Book{Title = "Pan",                                         AuthorId = 24,    PublishDate = new DateTime(1946, 04, 21)},
                    new Book{Title = "Pretty Poison",                               AuthorId = 7,     PublishDate = new DateTime(1909, 04, 08)},
                    new Book{Title = "Life On A String ",                           AuthorId = 16,    PublishDate = new DateTime(1980, 12, 11)},
                    new Book{Title = "Big Bounce, The",                             AuthorId = 3,     PublishDate = new DateTime(1974, 12, 30)},
                    new Book{Title = "Fiancee, The (Parineeta)",                    AuthorId = 25,    PublishDate = new DateTime(1969, 01, 01)},
                    new Book{Title = "Westward Ho",                                 AuthorId = 6,     PublishDate = new DateTime(1911, 11, 23)},
                    new Book{Title = "Sleepover",                                   AuthorId = 2,     PublishDate = new DateTime(1938, 02, 07)},
                    new Book{Title = "Trouble Every Day",                           AuthorId = 27,    PublishDate = new DateTime(1960, 12, 25)},
                    new Book{Title = "Defending Your Life",                         AuthorId = 5,     PublishDate = new DateTime(1985, 10, 24)},
                    new Book{Title = "Thoughtcrimes",                               AuthorId = 4,     PublishDate = new DateTime(1920, 06, 11)},
                    new Book{Title = "Batman",                                      AuthorId = 12,    PublishDate = new DateTime(1932, 02, 21)},
                    new Book{Title = "Ms. 45",                                      AuthorId = 19,    PublishDate = new DateTime(1973, 11, 25)},
                    new Book{Title = "Billy's Holiday",                             AuthorId = 19,    PublishDate = new DateTime(1999, 07, 07)},
                    new Book{Title = "Deep Rising",                                 AuthorId = 13,    PublishDate = new DateTime(1905, 01, 02)},
                    new Book{Title = "Black Balloon, The",                          AuthorId = 26,    PublishDate = new DateTime(1991, 01, 16)},
                    new Book{Title = "Expendables 2, The",                          AuthorId = 19,    PublishDate = new DateTime(1959, 04, 18)},
                    new Book{Title = "Trust Me",                                    AuthorId = 26,    PublishDate = new DateTime(1992, 07, 04)},
                    new Book{Title = "Clownhouse",                                  AuthorId = 4,     PublishDate = new DateTime(1935, 12, 10)},
                    new Book{Title = "China Syndrome, The",                         AuthorId = 7,     PublishDate = new DateTime(1921, 08, 29)},
                    new Book{Title = "Chinoise, La",                                AuthorId = 29,    PublishDate = new DateTime(1956, 07, 21)},
                    new Book{Title = "Carnosaur",                                   AuthorId = 25,    PublishDate = new DateTime(1987, 03, 18)},
                    new Book{Title = "Bastard Out of Carolina",                     AuthorId = 20,    PublishDate = new DateTime(1939, 09, 23)},
                    new Book{Title = "Le Week-End",                                 AuthorId = 17,    PublishDate = new DateTime(1948, 01, 24)},
                    new Book{Title = "Sister Kenny",                                AuthorId = 25,    PublishDate = new DateTime(1950, 09, 05)},
                    new Book{Title = "Z.P.G.",                                      AuthorId = 14,    PublishDate = new DateTime(1967, 10, 24)},
                    new Book{Title = "Superstar: The Karen Carpenter Story",        AuthorId = 12,    PublishDate = new DateTime(1980, 04, 30)},
                    new Book{Title = "Drunken Tai Chi (Siu taai gik)",              AuthorId = 14,    PublishDate = new DateTime(1914, 06, 29)},
                    new Book{Title = "Me and Orson Welles",                         AuthorId = 27,    PublishDate = new DateTime(1988, 05, 11)},
                    new Book{Title = "Besotted",                                    AuthorId = 2,     PublishDate = new DateTime(1925, 02, 08)},
                    new Book{Title = "Broken Vessels",                              AuthorId = 19,    PublishDate = new DateTime(1938, 09, 25)},
                    new Book{Title = "Formula, The",                                AuthorId = 1,     PublishDate = new DateTime(1996, 07, 07)},
                    new Book{Title = "Stop-Loss",                                   AuthorId = 2,     PublishDate = new DateTime(1959, 08, 19)},
                    new Book{Title = "Identity Thief",                              AuthorId = 25,    PublishDate = new DateTime(1954, 04, 21)},
                    new Book{Title = "Spirit: Stallion of the Cimarron",            AuthorId = 22,    PublishDate = new DateTime(1940, 02, 20)},
                    new Book{Title = "Beginning of the End",                        AuthorId = 16,    PublishDate = new DateTime(1930, 11, 02)},
                    new Book{Title = "For Those in Peril",                          AuthorId = 18,    PublishDate = new DateTime(1966, 03, 19)},
                    new Book{Title = "Jaws 2",                                      AuthorId = 28,    PublishDate = new DateTime(1995, 08, 22)},
                    new Book{Title = "Great White Hope, The",                       AuthorId = 5,     PublishDate = new DateTime(1989, 01, 28)},
                    new Book{Title = "Shadows of a Hot Summer",                     AuthorId = 19,    PublishDate = new DateTime(1953, 09, 07)},
                    new Book{Title = "Exiles (Exils)",                              AuthorId = 18,    PublishDate = new DateTime(1930, 05, 26)},
                    new Book{Title = "Italian for Beginners ",                      AuthorId = 4,     PublishDate = new DateTime(1947, 01, 09)},
                    new Book{Title = "Psycho II",                                   AuthorId = 22,    PublishDate = new DateTime(1929, 06, 12)},
                    new Book{Title = "Pathfinder",                                  AuthorId = 25,    PublishDate = new DateTime(1946, 12, 20)},
                    new Book{Title = "Commitments, The",                            AuthorId = 17,    PublishDate = new DateTime(1901, 05, 02)},
                    new Book{Title = "20 Seconds of Joy",                           AuthorId = 4,     PublishDate = new DateTime(1907, 05, 11)},
                    new Book{Title = "Ice Rink, The (La patinoire)",                AuthorId = 13,    PublishDate = new DateTime(1993, 02, 01)},
                    new Book{Title = "World According to Monsanto",                 AuthorId = 14,    PublishDate = new DateTime(1932, 03, 03)},
                    new Book{Title = "She Done Him Wrong",                          AuthorId = 12,    PublishDate = new DateTime(1983, 08, 14)},
                    new Book{Title = "Crow, The: Wicked Prayer",                    AuthorId = 9,     PublishDate = new DateTime(1955, 08, 20)},
                    new Book{Title = "Anthony Adverse",                             AuthorId = 18,    PublishDate = new DateTime(1933, 03, 28)},
                    new Book{Title = "Fortune Cookie, The",                         AuthorId = 27,    PublishDate = new DateTime(1956, 09, 18)},
                    new Book{Title = "Pleasure of Being Robbed, The",               AuthorId = 26,    PublishDate = new DateTime(1970, 05, 29)},
                    new Book{Title = "I've Loved You So Long",                      AuthorId = 28,    PublishDate = new DateTime(1910, 11, 04)},
                    new Book{Title = "Koch",                                        AuthorId = 19,    PublishDate = new DateTime(1913, 10, 08)},
                    new Book{Title = "For the Moment",                              AuthorId = 19,    PublishDate = new DateTime(1966, 10, 13)},
                    new Book{Title = "Locals, The",                                 AuthorId = 10,    PublishDate = new DateTime(1913, 03, 30)},
                    new Book{Title = "Living Death",                                AuthorId = 4,     PublishDate = new DateTime(1910, 12, 27)},
                    new Book{Title = "Assault on Precinct 13",                      AuthorId = 26,    PublishDate = new DateTime(1982, 08, 12)},
                    new Book{Title = "Beyond Rangoon",                              AuthorId = 19,    PublishDate = new DateTime(1956, 11, 20)},
                    new Book{Title = "Crimson Kimono, The",                         AuthorId = 29,    PublishDate = new DateTime(1926, 06, 04)},
                    new Book{Title = "Wirey Spindell",                              AuthorId = 21,    PublishDate = new DateTime(1918, 12, 24)},
                    new Book{Title = "Experience, The (Tadjrebeh)",                 AuthorId = 17,    PublishDate = new DateTime(1934, 06, 23)},
                    new Book{Title = "Trinity: Gambling for High Stakes",           AuthorId = 17,    PublishDate = new DateTime(1989, 04, 19)},
                    new Book{Title = "Merrily We Live",                             AuthorId = 26,    PublishDate = new DateTime(1952, 03, 17)},
                    new Book{Title = "March of the Movies",                         AuthorId = 9,     PublishDate = new DateTime(1929, 11, 14)},
                    new Book{Title = "At Any Second (In jeder Sekunde)",            AuthorId = 29,    PublishDate = new DateTime(1992, 05, 08)},
                    new Book{Title = "Daughter from Danang",                        AuthorId = 21,    PublishDate = new DateTime(1903, 02, 28)},
                    new Book{Title = "Miami Rhapsody",                              AuthorId = 12,    PublishDate = new DateTime(1902, 03, 26)},
                    new Book{Title = "Breakaway (Speedy Singhs)",                   AuthorId = 7,     PublishDate = new DateTime(1943, 07, 20)},
                    new Book{Title = "Poison Ivy II",                               AuthorId = 2,     PublishDate = new DateTime(1998, 03, 14)},
                    new Book{Title = "Caddyshack II",                               AuthorId = 23,    PublishDate = new DateTime(1948, 11, 03)},
                    new Book{Title = "Joe's Palace",                                AuthorId = 20,    PublishDate = new DateTime(1960, 02, 26)},
                    new Book{Title = "Overcoat, The (Il cappotto)",                 AuthorId = 12,    PublishDate = new DateTime(1953, 02, 08)},
                    new Book{Title = "Business of Fancydancing, The",               AuthorId = 1,     PublishDate = new DateTime(1978, 10, 06)},
                    new Book{Title = "Cronos",                                      AuthorId = 26,    PublishDate = new DateTime(1933, 08, 27)},
                    new Book{Title = "24: Redemption",                              AuthorId = 8,     PublishDate = new DateTime(1962, 08, 13)},
                    new Book{Title = "Harmony and Me",                              AuthorId = 15,    PublishDate = new DateTime(1902, 09, 06)},
                    new Book{Title = "Hamlet (Gamlet)",                             AuthorId = 8,     PublishDate = new DateTime(1974, 11, 28)},
                    new Book{Title = "Teenage Mutant Ninja Turtles",                AuthorId = 11,    PublishDate = new DateTime(1991, 02, 04)}
                    #endregion
                    );

                context.Members.AddRange(
                    #region Member Data
                    new Member{Name = "Ailee",      Surname = "Roggero",            BirthDay = new DateTime(1992, 07, 06), State = true, City = "Sarkand"},
                    new Member{Name = "Sharona",    Surname = "Wearing",            BirthDay = new DateTime(1997, 09, 28), State = true, City = "Maghār"},
                    new Member{Name = "Gallard",    Surname = "Kunneke",            BirthDay = new DateTime(1991, 07, 01), State = true, City = "Mbandjok"},
                    new Member{Name = "El",         Surname = "Nathon",             BirthDay = new DateTime(1995, 05, 12), State = true, City = "Molinos"},
                    new Member{Name = "Ginni",      Surname = "Wroth",              BirthDay = new DateTime(1995, 08, 20), State = true, City = "Bakung Utara"},
                    new Member{Name = "Trula",      Surname = "Sturman",            BirthDay = new DateTime(1991, 07, 21), State = true, City = "Ganggawang"},
                    new Member{Name = "Lon",        Surname = "Luty",               BirthDay = new DateTime(1991, 10, 19), State = true, City = "Tlumach"},
                    new Member{Name = "Jamison",    Surname = "Sturgess",           BirthDay = new DateTime(1996, 01, 03), State = true, City = "Kebonbencoy"},
                    new Member{Name = "Roarke",     Surname = "Painswick",          BirthDay = new DateTime(1996, 01, 16), State = true, City = "Vanino"},
                    new Member{Name = "Jennee",     Surname = "Van Salzberger",     BirthDay = new DateTime(1992, 05, 07), State = true, City = "Lemenhe"},
                    new Member{Name = "Dory",       Surname = "Lille",              BirthDay = new DateTime(1991, 03, 15), State = true, City = "Luocun"},
                    new Member{Name = "Craig",      Surname = "Kyffin",             BirthDay = new DateTime(1999, 02, 01), State = true, City = "Xankandi"},
                    new Member{Name = "Emelda",     Surname = "Edmons",             BirthDay = new DateTime(1998, 05, 18), State = true, City = "Zhengwan"},
                    new Member{Name = "Madlen",     Surname = "Colbert",            BirthDay = new DateTime(1996, 06, 13), State = true, City = "Chojnów"},
                    new Member{Name = "Sandra",     Surname = "Ishchenko",          BirthDay = new DateTime(1996, 03, 26), State = true, City = "Nový Knín"},
                    new Member{Name = "Norene",     Surname = "Stroud",             BirthDay = new DateTime(1996, 03, 11), State = true, City = "Drásov"},
                    new Member{Name = "Phil",       Surname = "Tunder",             BirthDay = new DateTime(2000, 07, 01), State = true, City = "Meishan"},
                    new Member{Name = "Ardeen",     Surname = "Blatherwick",        BirthDay = new DateTime(1997, 09, 25), State = true, City = "Jetis"},
                    new Member{Name = "Killie",     Surname = "Mottershaw",         BirthDay = new DateTime(1992, 03, 23), State = true, City = "Uluarang"},
                    new Member{Name = "Drusi",      Surname = "Navan",              BirthDay = new DateTime(1991, 08, 22), State = true, City = "Krajan"},
                    new Member{Name = "Bronnie",    Surname = "Jori",               BirthDay = new DateTime(1991, 11, 03), State = true, City = "Kapunduk"},
                    new Member{Name = "Edmon",      Surname = "Rumbold",            BirthDay = new DateTime(2000, 10, 03), State = true, City = "Sanxing"},
                    new Member{Name = "Domeniga",   Surname = "Gilbride",           BirthDay = new DateTime(1994, 09, 28), State = true, City = "Křižanov"},
                    new Member{Name = "Morgan",     Surname = "Wigan",              BirthDay = new DateTime(1997, 10, 12), State = true, City = "Manama"},
                    new Member{Name = "Sigismond",  Surname = "Huntingdon",         BirthDay = new DateTime(1996, 04, 07), State = true, City = "Oslo"}
                    #endregion
                    );
                context.Borrowings.AddRange(
                    new Borrowing { BookId = 1, BorrowerId = 1, Date = DateTime.Now },
                    new Borrowing { BookId = 2, BorrowerId = 1, Date = DateTime.Now },
                    new Borrowing { BookId = 3, BorrowerId = 1, Date = DateTime.Now },
                    new Borrowing { BookId = 4, BorrowerId = 1, Date = DateTime.Now },
                    new Borrowing { BookId = 5, BorrowerId = 1, Date = DateTime.Now },
                    new Borrowing { BookId = 6, BorrowerId = 1, Date = DateTime.Now }
                    );
                context.SaveChanges();
            }
        }
    }
}
