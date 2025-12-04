/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class dress_book_item : GComponent
    {
        public GLoader bg;
        public GLoader pic;
        public GLoader rare_img;
        public GImage n20;
        public GTextField nameLab;
        public GList stars;
        public probar2 pro;
        public GRichTextField proLab;
        public const string URL = "ui://argzn455m3gh4t";

        public static dress_book_item CreateInstance()
        {
            return (dress_book_item)UIPackage.CreateObject("fun_Dress", "dress_book_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            rare_img = (GLoader)GetChildAt(2);
            n20 = (GImage)GetChildAt(3);
            nameLab = (GTextField)GetChildAt(4);
            stars = (GList)GetChildAt(5);
            pro = (probar2)GetChildAt(6);
            proLab = (GRichTextField)GetChildAt(7);
        }
    }
}