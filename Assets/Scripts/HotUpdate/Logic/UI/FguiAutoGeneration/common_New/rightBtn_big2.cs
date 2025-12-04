/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class rightBtn_big2 : GButton
    {
        public Controller button;
        public GImage n4;
        public const string URL = "ui://mjiw43v9iust1yjp7sr";

        public static rightBtn_big2 CreateInstance()
        {
            return (rightBtn_big2)UIPackage.CreateObject("common_New", "rightBtn_big2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n4 = (GImage)GetChildAt(0);
        }
    }
}