/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_plant
{
    public partial class reward_show_view : GComponent
    {
        public Controller empty;
        public GImage n2;
        public GLoader bg;
        public GImage n3;
        public GImage n6;
        public GImage n4;
        public GTextField tipLab;
        public GGroup n8;
        public GButton close_btn;
        public GImage n9;
        public GImage n10;
        public GTextField preLab;
        public GTextField extraLab;
        public GList pre_list;
        public GList extra_list;
        public GGroup n16;
        public const string URL = "ui://qfpad3q0tewh16";

        public static reward_show_view CreateInstance()
        {
            return (reward_show_view)UIPackage.CreateObject("fun_Guild_plant", "reward_show_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            empty = GetControllerAt(0);
            n2 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n3 = (GImage)GetChildAt(2);
            n6 = (GImage)GetChildAt(3);
            n4 = (GImage)GetChildAt(4);
            tipLab = (GTextField)GetChildAt(5);
            n8 = (GGroup)GetChildAt(6);
            close_btn = (GButton)GetChildAt(7);
            n9 = (GImage)GetChildAt(8);
            n10 = (GImage)GetChildAt(9);
            preLab = (GTextField)GetChildAt(10);
            extraLab = (GTextField)GetChildAt(11);
            pre_list = (GList)GetChildAt(12);
            extra_list = (GList)GetChildAt(13);
            n16 = (GGroup)GetChildAt(14);
        }
    }
}