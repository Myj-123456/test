/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class chose_back_item : GButton
    {
        public Controller button;
        public GImage n0;
        public GImage n2;
        public GTextField nameLab;
        public const string URL = "ui://argzn455xc4q1yjp82m";

        public static chose_back_item CreateInstance()
        {
            return (chose_back_item)UIPackage.CreateObject("fun_Dress", "chose_back_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n0 = (GImage)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            nameLab = (GTextField)GetChildAt(2);
        }
    }
}