/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class greenBtn : GButton
    {
        public GImage n6;
        public GTextField titleLab;
        public const string URL = "ui://mjiw43v9ja6i1yjp7si";

        public static greenBtn CreateInstance()
        {
            return (greenBtn)UIPackage.CreateObject("common_New", "greenBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
        }
    }
}