/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class common_add1 : GButton
    {
        public Controller type;
        public GImage n2;
        public GImage n3;
        public GImage n4;
        public const string URL = "ui://mjiw43v9dhbs1yjp85o";

        public static common_add1 CreateInstance()
        {
            return (common_add1)UIPackage.CreateObject("common_New", "common_add1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            n2 = (GImage)GetChildAt(0);
            n3 = (GImage)GetChildAt(1);
            n4 = (GImage)GetChildAt(2);
        }
    }
}