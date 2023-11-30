using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Services
{
    public interface ICustomisedMessagePrinter
    {
        public void WriteTitle(params object[] TitleObj);
        public void WriteMessage(bool newLine, params object[] messageParams);
    }
}
