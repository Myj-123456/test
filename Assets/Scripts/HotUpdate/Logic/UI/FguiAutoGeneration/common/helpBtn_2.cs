/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common
{
    public partial class helpBtn_2 : GButton
    {
        public Controller button;
        public GImage n3;
        public const string URL = "ui://6bdpq80knwgi1yjp7ri";

        public static helpBtn_2 CreateInstance()
        {
            return (helpBtn_2)UIPackage.CreateObject("common", "helpBtn_2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n3 = (GImage)GetChildAt(0);
        }
    }
}