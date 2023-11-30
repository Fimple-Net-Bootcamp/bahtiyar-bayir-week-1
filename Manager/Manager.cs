using AutoMapper;
using fimple_bootcamp_week_1_homework.DBOperations;
using fimple_bootcamp_week_1_homework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.Write(dbContext.Books.FirstOrDefault(b => b.Id == 1).Title);
        }
    }
}
