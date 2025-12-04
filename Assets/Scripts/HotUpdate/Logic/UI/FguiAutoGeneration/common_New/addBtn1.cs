/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class addBtn1 : GButton
    {
        public Controller button;
        public GImage n0;
        public GImage n1;
        public const string URL = "ui://mjiw43v9q9bj1yjp7u8";

        public static addBtn1 CreateInstance()
        {
            return (addBtn1)UIPackage.CreateObject("common_New", "addBtn1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n0 = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
        }
    }
}