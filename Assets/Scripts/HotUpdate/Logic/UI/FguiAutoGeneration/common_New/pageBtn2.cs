/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class pageBtn2 : GButton
    {
        public Controller button;
        public GImage n8;
        public GTextField titleLab;
        public const string URL = "ui://mjiw43v9i64u1yjp7t0";

        public static pageBtn2 CreateInstance()
        {
            return (pageBtn2)UIPackage.CreateObject("common_New", "pageBtn2");
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