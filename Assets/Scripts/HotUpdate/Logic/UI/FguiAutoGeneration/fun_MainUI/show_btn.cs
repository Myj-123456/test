/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MainUI
{
    public partial class show_btn : GButton
    {
        public GImage n0;
        public GImage red_point;
        public const string URL = "ui://fa0hi8ybu25n1ayr84e";

        public static show_btn CreateInstance()
        {
            return (show_btn)UIPackage.CreateObject("fun_MainUI", "show_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            red_point = (GImage)GetChildAt(1);
        }
    }
}