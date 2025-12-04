/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Pet
{
    public partial class treasure_info_view : GComponent
    {
        public GLoader bg;
        public GLoader bg1;
        public GImage n4;
        public GImage n8;
        public GButton close_btn;
        public GLoader icon;
        public GTextField nameLab;
        public GTextField decLab;
        public GTextField subtitleLab;
        public GList list;
        public const string URL = "ui://o7kmyysdx92m13";

        public static treasure_info_view CreateInstance()
        {
            return (treasure_info_view)UIPackage.CreateObject("fun_Pet", "treasure_info_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            bg1 = (GLoader)GetChildAt(1);
            n4 = (GImage)GetChildAt(2);
            n8 = (GImage)GetChildAt(3);
            close_btn = (GButton)GetChildAt(4);
            icon = (GLoader)GetChildAt(5);
            nameLab = (GTextField)GetChildAt(6);
            decLab = (GTextField)GetChildAt(7);
            subtitleLab = (GTextField)GetChildAt(8);
            list = (GList)GetChildAt(9);
        }
    }
}