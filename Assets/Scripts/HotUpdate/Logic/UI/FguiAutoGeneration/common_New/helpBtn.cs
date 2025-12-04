/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class helpBtn : GButton
    {
        public Controller button;
        public GImage n4;
        public const string URL = "ui://mjiw43v9nd7j1yjp7rw";

        public static helpBtn CreateInstance()
        {
            return (helpBtn)UIPackage.CreateObject("common_New", "helpBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n4 = (GImage)GetChildAt(0);
        }
    }
}