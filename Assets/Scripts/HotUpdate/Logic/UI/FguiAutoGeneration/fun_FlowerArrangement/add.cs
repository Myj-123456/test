/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerArrangement
{
    public partial class add : GButton
    {
        public Controller c1;
        public GImage n9;
        public GImage n7;
        public const string URL = "ui://6kofjj39v1yd1ayr7t5";

        public static add CreateInstance()
        {
            return (add)UIPackage.CreateObject("fun_FlowerArrangement", "add");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            n9 = (GImage)GetChildAt(0);
            n7 = (GImage)GetChildAt(1);
        }
    }
}