/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Customer
{
    public partial class role_item : GButton
    {
        public Controller button;
        public GLoader pic;
        public GImage n2;
        public const string URL = "ui://pcr735xhcs1mr";

        public static role_item CreateInstance()
        {
            return (role_item)UIPackage.CreateObject("fun_Customer", "role_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            pic = (GLoader)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
        }
    }
}