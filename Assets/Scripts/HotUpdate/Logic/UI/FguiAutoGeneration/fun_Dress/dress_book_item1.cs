/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class dress_book_item1 : GComponent
    {
        public GLoader bg;
        public GLoader pic;
        public GTextField nameLab;
        public const string URL = "ui://argzn455hstt1yjp83a";

        public static dress_book_item1 CreateInstance()
        {
            return (dress_book_item1)UIPackage.CreateObject("fun_Dress", "dress_book_item1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            nameLab = (GTextField)GetChildAt(2);
        }
    }
}