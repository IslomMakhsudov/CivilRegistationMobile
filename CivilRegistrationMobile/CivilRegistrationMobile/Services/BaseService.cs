namespace CivilRegistrationMobile.Services
{
    public class BaseService
    {
        public IconsColor ChangeColor(IconsColor iconsColor, int? pageCode)
        {
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
                    iconsColor.ThreeOneImage = "1-orange.png";
                    return iconsColor;
                case 3:
                    iconsColor.OneImage = "success.png";
                    iconsColor.TwoImage = "success.png";
                    iconsColor.ThreeImage = "3-orange.png";
                    iconsColor.ThreeOneImage = "success.png";
                    iconsColor.ThreeTwoImage = "2-orange.png";
                    return iconsColor;
                case 4:
                    iconsColor.OneImage = "success.png";
                    iconsColor.TwoImage = "success.png";
                    iconsColor.ThreeImage = "success.png";
                    iconsColor.ThreeOneImage = "success.png";
                    iconsColor.ThreeTwoImage = "success.png";
                    return iconsColor;
                default:
                    return iconsColor;
                    
            }
        }
    }
}
