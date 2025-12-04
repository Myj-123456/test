/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common
{
    public partial class rightBtn_big_3 : GButton
    {
        public Controller button;
        public GImage n4;
        public const string URL = "ui://6bdpq80knwgi1yjp7rg";

        public static rightBtn_big_3 CreateInstance()
        {
            return (rightBtn_big_3)UIPackage.CreateObject("common", "rightBtn_big_3");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n4 = (GImage)GetChildAt(0);
        }
    }
}