using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ZagsDbServerProject.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CivilRegistrationMobile.Services
{
    public class BaseService
    {
        public IconsColor ChangeColor(int? pageCode)
        {
            IconsColor iconsColor = new();
            switch (pageCode)
            {
                case 0:
                    return iconsColor;
                case null:
                    return iconsColor;
                case 1:
                    iconsColor.OneImage = "success.png";
                    iconsColor.TwoImage = "2-orange.png";
                    return iconsColor;
                case 2:
                    iconsColor.OneImage = "success.png";
                    iconsColor.TwoImage = "success.png";
                    iconsColor.ThreeImage = "3-orange.png";
                    return iconsColor;
                case 3:
                    iconsColor.OneImage = "success.png";
                    iconsColor.TwoImage = "success.png";
                    iconsColor.ThreeImage = "success.png";
                    iconsColor.FourImage = "4-orange.png";
                    return iconsColor;
                case 4:
                    iconsColor.OneImage = "success.png";
                    iconsColor.TwoImage = "success.png";
                    iconsColor.ThreeImage = "success.png";
                    iconsColor.FourImage = "success.png";
                    return iconsColor;
                default:
                    return iconsColor;
                    
            }
        }

        public bool CheckHash(HttpContext context)
        {
            string key = "47ct4956e3a4504e8193539e8252aa18";
            string uId = context.Request.Headers["uid"];
            string dateSync = context.Request.Headers["datesync"];
            string serverHash = context.Request.Headers["hash"];

            string hash = uId + key + dateSync;
            hash = CreateMD5(hash);

            DateTime dateStart = DateTime.Now.AddMinutes(-10);
            DateTime dateEnd = DateTime.Now.AddMinutes(10);

            string[] format = { "yyyyMMddHHmmssFFF" };
            DateTime date;

            if (hash.ToUpper() != serverHash)
            {
                return false;
            }

            if (DateTime.TryParseExact(dateSync, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                if (!(date >= dateStart && date <= dateEnd))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
