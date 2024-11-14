using System;
using System.IO;

namespace WindowsFormsApp11
{
    public class Helper
    {
        public static string ProfilPath(string tckimlikno, string type)
        {
            string path = string.Empty;

            switch (type)
            {
                case "admin":
                    path = $"{Directory.GetParent(Environment.CurrentDirectory).Parent.FullName}/Images/Admin/{tckimlikno}.jpg";
                    break;
                case "diyetisyen":
                    path = $"{Directory.GetParent(Environment.CurrentDirectory).Parent.FullName}/Images/Diyetisyen/{tckimlikno}.jpg";
                    break;
                case "danışma":
                    path = $"{Directory.GetParent(Environment.CurrentDirectory).Parent.FullName}/Images/Danışma/{tckimlikno}.jpg";
                    break;
                default:
                    path = $"{Directory.GetParent(Environment.CurrentDirectory).Parent.FullName}/Images/profile.png";
                    break;
            }

            if (!File.Exists(path))
            {
                path = $"{Directory.GetParent(Environment.CurrentDirectory).Parent.FullName}/Images/profile.png";
            }

            return path;
        }
    }
}
