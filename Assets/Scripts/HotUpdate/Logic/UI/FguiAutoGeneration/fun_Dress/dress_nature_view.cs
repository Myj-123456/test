/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class dress_nature_view : GComponent
    {
        public Controller show;
        public GImage n2;
        public GLoader bg;
        public GImage n3;
        public GImage n7;
        public GImage n8;
        public GImage n9;
        public GImage n14;
        public GImage n15;
        public GImage n23;
        public GImage n25;
        public GButton close_btn;
        public GTextField tipLab1;
        public GTextField tipLab2;
        public GTextField nullLab;
        public GTextField tipLab3;
        public GList list;
        public GTextField charmNum;
        public GTextField dressLab;
        public GTextField suitLab;
        public GTextField dressNum;
        public GTextField suitNum;
        public GList nature_list;
        public const string URL = "ui://argzn455hstt1yjp83j";

        public static dress_nature_view CreateInstance()
        {
            return (dress_nature_view)UIPackage.CreateObject("fun_Dress", "dress_nature_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            show = GetControllerAt(0);
            n2 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n3 = (GImage)GetChildAt(2);
            n7 = (GImage)GetChildAt(3);
            n8 = (GImage)GetChildAt(4);
            n9 = (GImage)GetChildAt(5);
            n14 = (GImage)GetChildAt(6);
            n15 = (GImage)GetChildAt(7);
            n23 = (GImage)GetChildAt(8);
            n25 = (GImage)GetChildAt(9);
            close_btn = (GButton)GetChildAt(10);
            tipLab1 = (GTextField)GetChildAt(11);
            tipLab2 = (GTextField)GetChildAt(12);
            nullLab = (GTextField)GetChildAt(13);
            tipLab3 = (GTextField)GetChildAt(14);
            list = (GList)GetChildAt(15);
            charmNum = (GTextField)GetChildAt(16);
            dressLab = (GTextField)GetChildAt(17);
            suitLab = (GTextField)GetChildAt(18);
            dressNum = (GTextField)GetChildAt(19);
            suitNum = (GTextField)GetChildAt(20);
            nature_list = (GList)GetChildAt(21);
        }
    }
}