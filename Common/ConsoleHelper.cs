using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ConsoleMenuHelper
    {
        private int X { get; set; }
        private int Y { get; set; }
        private int OptionPerLine { get; set; }
        private int SpacingPerLine { get; set; }
        private int SelectedItem { get; set; }
        private string[] Options { get; set; }

        public class Builder
        {
            public ConsoleMenuHelper consoleMenuHelper { get; set; }

            public Builder()
            {
                consoleMenuHelper = new ConsoleMenuHelper();
            }

            public Builder AddX(int value)
            {
                consoleMenuHelper.X = value;
                return this;
            }

            public Builder AddY(int value)
            {
                consoleMenuHelper.Y = value;
                return this;
            }
            public Builder AddOptionPerLine(int value)
            {
                consoleMenuHelper.OptionPerLine = value;
                return this;
            }
            public Builder AddOptions(string[] value)
            {
                consoleMenuHelper.Options = value;
                return this;
            }

            public Builder AddSpacingPerLine(int value)
            {
                consoleMenuHelper.SpacingPerLine = value;
                return this;
            }

            public ConsoleMenuHelper ToConsoleMenueHelper()
                => consoleMenuHelper;
        }

        private ConsoleMenuHelper() { }
        public string MultipleChoice(bool canCancel)
        {
            ConsoleKey key;
            Console.CursorVisible = false;

            do
            {
                for (int i = 0; i < Options.Length; i++)
                {
                    Console.SetCursorPosition(X + i % OptionPerLine * SpacingPerLine, Y + i / OptionPerLine);

                    if (i == SelectedItem)
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine(Options[i]);

                    Console.ResetColor();
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            if (SelectedItem % OptionPerLine > 0)
                                SelectedItem--;
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            if (SelectedItem % OptionPerLine < OptionPerLine - 1)
                                SelectedItem++;
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            if (SelectedItem >= OptionPerLine)
                                SelectedItem -= OptionPerLine;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (SelectedItem + OptionPerLine < Options.Length)
                                SelectedItem += OptionPerLine;
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            if (canCancel)
                                return "";
                            break;
                        }
                }
            } while (key != ConsoleKey.Enter);

            Console.CursorVisible = true;

            return Options[SelectedItem];
        }

    }
}
