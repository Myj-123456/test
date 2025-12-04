/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class rightBtn_big : GButton
    {
        public Controller button;
        public GImage n4;
        public const string URL = "ui://mjiw43v9lmjv1yjp7rw";

        public static rightBtn_big CreateInstance()
        {
            return (rightBtn_big)UIPackage.CreateObject("common_New", "rightBtn_big");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n4 = (GImage)GetChildAt(0);
        }
    }
}