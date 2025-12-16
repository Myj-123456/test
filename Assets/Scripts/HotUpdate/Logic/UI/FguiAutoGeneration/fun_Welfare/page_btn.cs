/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Welfare
{
    public partial class page_btn : GButton
    {
        public Controller button;
        public Controller status;
        public GImage n27;
        public GImage n28;
        public GTextField titleLab;
        public const string URL = "ui://awswhm01f26r1yjp84s";

        public static page_btn CreateInstance()
        {
            return (page_btn)UIPackage.CreateObject("fun_Welfare", "page_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            status = GetControllerAt(1);
            n27 = (GImage)GetChildAt(0);
            n28 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}