/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class btn_common : GButton
    {
        public Controller type;
        public GGraph n5;
        public GTextField titleLab;
        public GImage n8;
        public GImage n9;
        public GImage n10;
        public GImage n11;
        public const string URL = "ui://qz6135j3s62s1yjp7ys";

        public static btn_common CreateInstance()
        {
            return (btn_common)UIPackage.CreateObject("fun_Guild_New", "btn_common");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            n5 = (GGraph)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
            n8 = (GImage)GetChildAt(2);
            n9 = (GImage)GetChildAt(3);
            n10 = (GImage)GetChildAt(4);
            n11 = (GImage)GetChildAt(5);
        }
    }
}