/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class pageBtn4 : GButton
    {
        public Controller button;
        public GTextField titleLab;
        public GImage n8;
        public GTextField titleLab1;
        public const string URL = "ui://mjiw43v9z1vi1yjp82p";

        public static pageBtn4 CreateInstance()
        {
            return (pageBtn4)UIPackage.CreateObject("common_New", "pageBtn4");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            titleLab = (GTextField)GetChildAt(0);
            n8 = (GImage)GetChildAt(1);
            titleLab1 = (GTextField)GetChildAt(2);
        }
    }
}