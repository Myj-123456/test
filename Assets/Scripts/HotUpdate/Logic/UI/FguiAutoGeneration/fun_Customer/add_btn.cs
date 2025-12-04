/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Customer
{
    public partial class add_btn : GButton
    {
        public GImage n4;
        public const string URL = "ui://pcr735xhcs1mj";

        public static add_btn CreateInstance()
        {
            return (add_btn)UIPackage.CreateObject("fun_Customer", "add_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n4 = (GImage)GetChildAt(0);
        }
    }
}