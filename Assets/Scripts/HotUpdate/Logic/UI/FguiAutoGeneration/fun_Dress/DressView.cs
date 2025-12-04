/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class DressView : GComponent
    {
        public Controller tab;
        public cloth_view cloth_view;
        public dress_mian_book_view book_view;
        public GImage n24;
        public GTextField titleLab;
        public GButton help_btn;
        public GImage n40;
        public GImage n43;
        public GTextField txt_gold;
        public GImage n44;
        public GImage n45;
        public GTextField txt_diamond;
        public GImage n52;
        public GImage n67;
        public GButton close_btn;
        public pageBtn1 cloth_btn;
        public pageBtn1 book_btn;
        public GGroup n63;
        public const string URL = "ui://argzn455quk20";

        public static DressView CreateInstance()
        {
            return (DressView)UIPackage.CreateObject("fun_Dress", "DressView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tab = GetControllerAt(0);
            cloth_view = (cloth_view)GetChildAt(0);
            book_view = (dress_mian_book_view)GetChildAt(1);
            n24 = (GImage)GetChildAt(2);
            titleLab = (GTextField)GetChildAt(3);
            help_btn = (GButton)GetChildAt(4);
            n40 = (GImage)GetChildAt(5);
            n43 = (GImage)GetChildAt(6);
            txt_gold = (GTextField)GetChildAt(7);
            n44 = (GImage)GetChildAt(8);
            n45 = (GImage)GetChildAt(9);
            txt_diamond = (GTextField)GetChildAt(10);
            n52 = (GImage)GetChildAt(11);
            n67 = (GImage)GetChildAt(12);
            close_btn = (GButton)GetChildAt(13);
            cloth_btn = (pageBtn1)GetChildAt(14);
            book_btn = (pageBtn1)GetChildAt(15);
            n63 = (GGroup)GetChildAt(16);
        }
    }
}