/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class pageBtn2 : GButton
    {
        public Controller button;
        public GImage n11;
        public GImage n12;
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
            n11 = (GImage)GetChildAt(0);
            n12 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}