/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Chat
{
    public partial class page_btn : GButton
    {
        public Controller button;
        public Controller type;
        public GTextField titleLab;
        public GImage n3;
        public GGroup n5;
        public GImage n4;
        public GGroup n6;
        public GTextField titleLab1;
        public const string URL = "ui://z9jypfq811rnu1yjp7wt";

        public static page_btn CreateInstance()
        {
            return (page_btn)UIPackage.CreateObject("fun_Chat", "page_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            type = GetControllerAt(1);
            titleLab = (GTextField)GetChildAt(0);
            n3 = (GImage)GetChildAt(1);
            n5 = (GGroup)GetChildAt(2);
            n4 = (GImage)GetChildAt(3);
            n6 = (GGroup)GetChildAt(4);
            titleLab1 = (GTextField)GetChildAt(5);
        }
    }
}