using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fimple_bootcamp_week_1_homework.Services
{
    internal class CustomisedMessagePrinter : ICustomisedMessagePrinter
    {
        private int _lineWidth = 143;
        public CustomisedMessagePrinter()
        {
        }
        public void WriteTitle(params object[] TitleObj)
        {
            WriteMessage(false, ConsoleColor.Gray, new string('#', _lineWidth) + "\r\n#" + new string(' ', _lineWidth - 2) + "#\r\n#");

            if (TitleObj.Length > 2)
            {
                var titleLen = TitleObj.Where(obj => obj is not ConsoleColor || !Enum.IsDefined(typeof(ConsoleColor), obj)).ToList().Cast<string>().Sum(str => str.Length);
                WriteMessage(false, ConsoleColor.DarkBlue, new string(' ', ((_lineWidth / 2) - 1) - (titleLen / 2)));
                WriteMessage(false, TitleObj);
                WriteMessage(false, ConsoleColor.DarkBlue, new string(' ', ((_lineWidth / 2) - 1) - (titleLen / 2)));
            }
            else
            {
                WriteMessage(false, (ConsoleColor)TitleObj[0], new string(' ', ((_lineWidth / 2) - 1) - ((TitleObj[1].ToString().Length / 2)))
                                                + TitleObj[1].ToString() +
                                        new string(' ', ((_lineWidth / 2) - 1) - ((TitleObj[1].ToString().Length / 2))));
            }
            WriteMessage(true, ConsoleColor.Gray, "#\r\n#" + new string(' ', _lineWidth - 2) + "#\r\n" + new string('#', _lineWidth) + "\r\n\n");


        }
        public void WriteMessage(bool newLine, params object[] messageParams)
        {
            for (int i = 0; i < messageParams.Length; i += 2)
            {
                ConsoleColor color = (ConsoleColor)messageParams[i];
                string text = messageParams[i + 1].ToString();

                Console.ForegroundColor = color;
                Console.Write(text);
            }

            Console.ResetColor();
            if (newLine) Console.WriteLine();
        }
    }
}
