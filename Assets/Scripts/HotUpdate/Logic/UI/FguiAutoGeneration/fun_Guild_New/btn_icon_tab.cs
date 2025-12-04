/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class btn_icon_tab : GButton
    {
        public Controller button;
        public GImage n7;
        public GLoader icon;
        public GImage n5;
        public GTextField titleLab;
        public const string URL = "ui://qz6135j3s62s1yjp7yu";

        public static btn_icon_tab CreateInstance()
        {
            return (btn_icon_tab)UIPackage.CreateObject("fun_Guild_New", "btn_icon_tab");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n7 = (GImage)GetChildAt(0);
            icon = (GLoader)GetChildAt(1);
            n5 = (GImage)GetChildAt(2);
            titleLab = (GTextField)GetChildAt(3);
        }
    }
}