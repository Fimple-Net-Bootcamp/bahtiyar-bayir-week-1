using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Entitys
{
    public class Member : Person
    {
        public string City { get; set; }
        public DateTime BirthDay { get; set; }

        public Boolean State { get; set; } = true;

    }
}
