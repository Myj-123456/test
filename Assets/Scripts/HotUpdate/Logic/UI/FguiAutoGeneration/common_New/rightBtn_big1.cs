/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class rightBtn_big1 : GButton
    {
        public Controller button;
        public GImage n4;
        public const string URL = "ui://mjiw43v9ja6i1yjp7sj";

        public static rightBtn_big1 CreateInstance()
        {
            return (rightBtn_big1)UIPackage.CreateObject("common_New", "rightBtn_big1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n4 = (GImage)GetChildAt(0);
        }
    }
}