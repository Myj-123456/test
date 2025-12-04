/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common
{
    public partial class rightBtn_big_4 : GButton
    {
        public Controller button;
        public GImage n4;
        public const string URL = "ui://6bdpq80knwgi1yjp7rl";

        public static rightBtn_big_4 CreateInstance()
        {
            return (rightBtn_big_4)UIPackage.CreateObject("common", "rightBtn_big_4");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n4 = (GImage)GetChildAt(0);
        }
    }
}