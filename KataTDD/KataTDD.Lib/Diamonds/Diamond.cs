namespace KataTDD.Lib.Diamonds
{
    public class Diamond
    {
        public static string Create(char widestChar)
        {
            string result = null;
            int line = 1;
            int width = GetWidth(widestChar);

            result = WriteTopDiamond(widestChar, width, ref line);
            result += WriteChar(widestChar, line, width);
            result = WriteBottomDiamond(widestChar, line, result, width);

            return result;
        }

        private static string WriteTopDiamond(char widestChar, int width, ref int line)
        {
            string result = null;
            for (char c = 'A'; c < widestChar; c++)
            {
                result += WriteChar(c, line, width);
                line++;
            }
            return result;
        }

        private static string WriteBottomDiamond(char widestChar, int line, string result, int width)
        {
            for (char c = (char) (widestChar - 1); c >= 'A'; c--)
            {
                line--;
                result += WriteChar(c, line, width);
            }
            return result;
        }

        private static int GetWidth(char widestChar)
        {
            return (widestChar - 'A' + 1) * 2 - 1;
        }

        private static string WriteChar(char c, int line, int width)
        {
            return AppendLine(GetStringToAdd(c, line, width));
        }

        private static string GetStringToAdd(char c, int line, int width)
        {
            int indentation = GetNbIndentation(line, width);
            int nbSpace = GetNbSpace(width, indentation);
            string blanks = GetBlanks(indentation);

            return IsNotHighExtremity(line)
                ? blanks + c + GetBlanks(nbSpace) + c + blanks
                : blanks + c + blanks;
        }

        private static int GetNbSpace(int width, int indentation)
        {
            return width - 2 - 2 * indentation;
        }

        private static int GetNbIndentation(int line, int width)
        {
            return (width - 2 * line + 1) / 2;
        }

        private static bool IsNotHighExtremity(int line)
        {
            return line >= 2;
        }

        private static string GetBlanks(int nbBlank)
        {
            string blank = null;
            for (int i = 0; i < nbBlank; i++)
            {
                blank += ' ';
            }
            return blank;
        }

        private static string AppendLine(string result)
        {
            return result + "\n";
        }
    }
}