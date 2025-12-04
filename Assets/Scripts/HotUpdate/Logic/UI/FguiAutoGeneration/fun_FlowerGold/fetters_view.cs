/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerGold
{
    public partial class fetters_view : GComponent
    {
        public GLoader bg;
        public GImage n2;
        public GTextField titleLab;
        public GButton close_btn;
        public GList list;
        public const string URL = "ui://44kfvb3rv5lj1yjp81l";

        public static fetters_view CreateInstance()
        {
            return (fetters_view)UIPackage.CreateObject("fun_FlowerGold", "fetters_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
            close_btn = (GButton)GetChildAt(3);
            list = (GList)GetChildAt(4);
        }
    }
}