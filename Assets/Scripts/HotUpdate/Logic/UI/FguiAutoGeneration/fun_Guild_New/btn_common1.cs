/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class btn_common1 : GButton
    {
        public GImage n12;
        public GTextField titleLab;
        public const string URL = "ui://qz6135j3m3gh1yjp818";

        public static btn_common1 CreateInstance()
        {
            return (btn_common1)UIPackage.CreateObject("fun_Guild_New", "btn_common1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n12 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
        }
    }
}