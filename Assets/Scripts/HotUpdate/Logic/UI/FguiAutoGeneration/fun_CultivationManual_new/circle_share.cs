/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class circle_share : GButton
    {
        public Controller button;
        public GImage n3;
        public GImage n6;
        public GTextField titleLab;
        public const string URL = "ui://ekoic0wrd9bk1yjp7t7";

        public static circle_share CreateInstance()
        {
            return (circle_share)UIPackage.CreateObject("fun_CultivationManual_new", "circle_share");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n3 = (GImage)GetChildAt(0);
            n6 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}