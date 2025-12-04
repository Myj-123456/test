/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class dress_mian_book_view : GComponent
    {
        public Controller tab;
        public GLoader bg;
        public suit_book_view suit_view;
        public dress_book_view dress_view;
        public pageBtn2 suit_btn;
        public pageBtn2 dress_btn;
        public GImage n24;
        public GImage n25;
        public GGroup n29;
        public GImage n23;
        public GImage n22;
        public GImage n28;
        public GTextField powerNum;
        public btn2 detail_btn;
        public GGroup n30;
        public const string URL = "ui://argzn455hstt1yjp831";

        public static dress_mian_book_view CreateInstance()
        {
            return (dress_mian_book_view)UIPackage.CreateObject("fun_Dress", "dress_mian_book_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tab = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            suit_view = (suit_book_view)GetChildAt(1);
            dress_view = (dress_book_view)GetChildAt(2);
            suit_btn = (pageBtn2)GetChildAt(3);
            dress_btn = (pageBtn2)GetChildAt(4);
            n24 = (GImage)GetChildAt(5);
            n25 = (GImage)GetChildAt(6);
            n29 = (GGroup)GetChildAt(7);
            n23 = (GImage)GetChildAt(8);
            n22 = (GImage)GetChildAt(9);
            n28 = (GImage)GetChildAt(10);
            powerNum = (GTextField)GetChildAt(11);
            detail_btn = (btn2)GetChildAt(12);
            n30 = (GGroup)GetChildAt(13);
        }
    }
}