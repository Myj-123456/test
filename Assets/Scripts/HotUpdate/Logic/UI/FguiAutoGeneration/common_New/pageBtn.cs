/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class pageBtn : GButton
    {
        public Controller button;
        public GImage n8;
        public GTextField titleLab;
        public const string URL = "ui://mjiw43v9e87c1ayr7z4";

        public static pageBtn CreateInstance()
        {
            return (pageBtn)UIPackage.CreateObject("common_New", "pageBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n8 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
        }
    }
}