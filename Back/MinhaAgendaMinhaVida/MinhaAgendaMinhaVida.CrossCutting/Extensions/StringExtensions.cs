using System.Text;

namespace MinhaAgendaMinhaVida.CrossCutting.Extensions
{
    public static class StringExtensions
    {
        public static string NormalizeWhiteSpaces(this string str)
        {
            var s = str.Trim();
            var isWhite = false;
            var sLength = s.Length;
            var sb = new StringBuilder(sLength);

            for (var index = 0; index < s.ToCharArray().Length; index++)
            {
                var c = s.ToCharArray()[index];
                switch (char.IsWhiteSpace(c))
                {
                    case false:
                        sb.Append(c.ToString());
                        isWhite = false;
                        break;
                    default:
                    {
                        if (isWhite)
                        {
                        }
                        else
                        {
                            sb.Append(" ");
                            isWhite = true;
                        }

                        break;
                    }
                }
            }

            return sb.ToString();
        }
    }
}