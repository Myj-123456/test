/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class btn_shovelAll : GButton
    {
        public GImage n4;
        public GImage n5;
        public GImage n8;
        public GTextField titleLab;
        public const string URL = "ui://dpcxz2finwd51d";

        public static btn_shovelAll CreateInstance()
        {
            return (btn_shovelAll)UIPackage.CreateObject("fun_Scene", "btn_shovelAll");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n4 = (GImage)GetChildAt(0);
            n5 = (GImage)GetChildAt(1);
            n8 = (GImage)GetChildAt(2);
            titleLab = (GTextField)GetChildAt(3);
        }
    }
}