/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common
{
    public partial class blueBgBtn : GButton
    {
        public GImage n6;
        public GTextField titleLab;
        public const string URL = "ui://6bdpq80knwgi1yjp7ro";

        public static blueBgBtn CreateInstance()
        {
            return (blueBgBtn)UIPackage.CreateObject("common", "blueBgBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
        }
    }
}