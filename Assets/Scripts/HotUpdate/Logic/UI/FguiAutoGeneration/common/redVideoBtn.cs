/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common
{
    public partial class redVideoBtn : GButton
    {
        public GImage n6;
        public GTextField titleLab;
        public GImage n10;
        public const string URL = "ui://6bdpq80knwgi1yjp7rj";

        public static redVideoBtn CreateInstance()
        {
            return (redVideoBtn)UIPackage.CreateObject("common", "redVideoBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
            n10 = (GImage)GetChildAt(2);
        }
    }
}