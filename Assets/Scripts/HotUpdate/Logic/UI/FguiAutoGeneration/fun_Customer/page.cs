/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Customer
{
    public partial class page : GButton
    {
        public Controller button;
        public GImage n4;
        public GImage n5;
        public GTextField titleLab;
        public GTextField titleLab1;
        public const string URL = "ui://pcr735xhcs1mg";

        public static page CreateInstance()
        {
            return (page)UIPackage.CreateObject("fun_Customer", "page");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n4 = (GImage)GetChildAt(0);
            n5 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
            titleLab1 = (GTextField)GetChildAt(3);
        }
    }
}