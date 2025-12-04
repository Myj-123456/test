/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_SignInSevenDays
{
    public partial class SeventhSign : GComponent
    {
        public Controller title;
        public Controller isToday;
        public Controller isLock;
        public GLoader bg;
        public GImage n138;
        public GImage n139;
        public GImage n141;
        public GLoader3D anim;
        public GImage n142;
        public GImage n144;
        public GImage n145;
        public GImage n143;
        public GTextField desc_txt;
        public GTextField desc_txt1;
        public GButton close_btn;
        public SeventhSign_Item item0;
        public SeventhSign_Item item1;
        public SeventhSign_Item item2;
        public SeventhSign_Item item3;
        public SeventhSign_Item item4;
        public SeventhSign_Item item5;
        public SeventhSign_Item2 item6;
        public Transition animation;
        public const string URL = "ui://zrkg0kw2g0qq1ayr7vs";

        public static SeventhSign CreateInstance()
        {
            return (SeventhSign)UIPackage.CreateObject("fun_SignInSevenDays", "SeventhSign");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            title = GetControllerAt(0);
            isToday = GetControllerAt(1);
            isLock = GetControllerAt(2);
            bg = (GLoader)GetChildAt(0);
            n138 = (GImage)GetChildAt(1);
            n139 = (GImage)GetChildAt(2);
            n141 = (GImage)GetChildAt(3);
            anim = (GLoader3D)GetChildAt(4);
            n142 = (GImage)GetChildAt(5);
            n144 = (GImage)GetChildAt(6);
            n145 = (GImage)GetChildAt(7);
            n143 = (GImage)GetChildAt(8);
            desc_txt = (GTextField)GetChildAt(9);
            desc_txt1 = (GTextField)GetChildAt(10);
            close_btn = (GButton)GetChildAt(11);
            item0 = (SeventhSign_Item)GetChildAt(12);
            item1 = (SeventhSign_Item)GetChildAt(13);
            item2 = (SeventhSign_Item)GetChildAt(14);
            item3 = (SeventhSign_Item)GetChildAt(15);
            item4 = (SeventhSign_Item)GetChildAt(16);
            item5 = (SeventhSign_Item)GetChildAt(17);
            item6 = (SeventhSign_Item2)GetChildAt(18);
            animation = GetTransitionAt(0);
        }
    }
}