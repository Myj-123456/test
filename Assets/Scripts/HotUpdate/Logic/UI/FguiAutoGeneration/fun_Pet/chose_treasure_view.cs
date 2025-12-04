/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Pet
{
    public partial class chose_treasure_view : GComponent
    {
        public Controller status;
        public GImage n14;
        public GImage n1;
        public GImage n3;
        public GImage n4;
        public GImage n5;
        public GImage n9;
        public GImage n10;
        public GImage n8;
        public GLoader icon;
        public GTextField nameLab;
        public GTextField tipLab;
        public GTextField titleLab;
        public GButton close_btn;
        public GButton sure_btn;
        public GList list;
        public const string URL = "ui://o7kmyysdx92mw";

        public static chose_treasure_view CreateInstance()
        {
            return (chose_treasure_view)UIPackage.CreateObject("fun_Pet", "chose_treasure_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n14 = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
            n3 = (GImage)GetChildAt(2);
            n4 = (GImage)GetChildAt(3);
            n5 = (GImage)GetChildAt(4);
            n9 = (GImage)GetChildAt(5);
            n10 = (GImage)GetChildAt(6);
            n8 = (GImage)GetChildAt(7);
            icon = (GLoader)GetChildAt(8);
            nameLab = (GTextField)GetChildAt(9);
            tipLab = (GTextField)GetChildAt(10);
            titleLab = (GTextField)GetChildAt(11);
            close_btn = (GButton)GetChildAt(12);
            sure_btn = (GButton)GetChildAt(13);
            list = (GList)GetChildAt(14);
        }
    }
}