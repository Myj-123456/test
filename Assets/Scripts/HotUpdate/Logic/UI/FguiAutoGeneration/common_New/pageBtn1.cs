/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class pageBtn1 : GButton
    {
        public Controller button;
        public GTextField titleLab;
        public GImage n8;
        public GTextField titleLab1;
        public const string URL = "ui://mjiw43v9iust1yjp7su";

        public static pageBtn1 CreateInstance()
        {
            return (pageBtn1)UIPackage.CreateObject("common_New", "pageBtn1");
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