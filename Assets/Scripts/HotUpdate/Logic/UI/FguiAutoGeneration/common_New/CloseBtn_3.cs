/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class CloseBtn_3 : GButton
    {
        public Controller button;
        public GImage n7;
        public const string URL = "ui://mjiw43v9s5f01yjp86g";

        public static CloseBtn_3 CreateInstance()
        {
            return (CloseBtn_3)UIPackage.CreateObject("common_New", "CloseBtn_3");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n7 = (GImage)GetChildAt(0);
        }
    }
}