/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class CloseBtn_1 : GButton
    {
        public Controller button;
        public GImage n4;
        public const string URL = "ui://mjiw43v9lmjv1yjp7s8";

        public static CloseBtn_1 CreateInstance()
        {
            return (CloseBtn_1)UIPackage.CreateObject("common_New", "CloseBtn_1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n4 = (GImage)GetChildAt(0);
        }
    }
}