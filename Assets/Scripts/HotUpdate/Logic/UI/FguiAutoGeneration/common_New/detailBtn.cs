/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class detailBtn : GButton
    {
        public Controller button;
        public GImage n0;
        public const string URL = "ui://mjiw43v9q47x1yjp7vf";

        public static detailBtn CreateInstance()
        {
            return (detailBtn)UIPackage.CreateObject("common_New", "detailBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n0 = (GImage)GetChildAt(0);
        }
    }
}