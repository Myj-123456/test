/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class btn : GButton
    {
        public Controller type;
        public GImage n13;
        public GImage n16;
        public GTextField titleLab;
        public const string URL = "ui://qz6135j3v01m1yjp81j";

        public static btn CreateInstance()
        {
            return (btn)UIPackage.CreateObject("fun_Guild_New", "btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            n13 = (GImage)GetChildAt(0);
            n16 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}