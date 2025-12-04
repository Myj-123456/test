/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class CloseBtn : GButton
    {
        public Controller button;
        public GImage n4;
        public const string URL = "ui://mjiw43v9pj271yjp7rx";

        public static CloseBtn CreateInstance()
        {
            return (CloseBtn)UIPackage.CreateObject("common_New", "CloseBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n4 = (GImage)GetChildAt(0);
        }
    }
}