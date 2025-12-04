/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common
{
    public partial class okBtn : GButton
    {
        public Controller button;
        public GImage n4;
        public const string URL = "ui://6bdpq80knwgi1yjp7mm";

        public static okBtn CreateInstance()
        {
            return (okBtn)UIPackage.CreateObject("common", "okBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n4 = (GImage)GetChildAt(0);
        }
    }
}