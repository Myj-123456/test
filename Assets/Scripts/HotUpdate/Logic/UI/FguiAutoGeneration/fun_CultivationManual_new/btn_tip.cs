/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class btn_tip : GButton
    {
        public Controller type;
        public GImage n3;
        public GImage n9;
        public GImage n10;
        public GImage n11;
        public GTextField titleLab;
        public const string URL = "ui://ekoic0wrq47x1yjp7vh";

        public static btn_tip CreateInstance()
        {
            return (btn_tip)UIPackage.CreateObject("fun_CultivationManual_new", "btn_tip");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            n3 = (GImage)GetChildAt(0);
            n9 = (GImage)GetChildAt(1);
            n10 = (GImage)GetChildAt(2);
            n11 = (GImage)GetChildAt(3);
            titleLab = (GTextField)GetChildAt(4);
        }
    }
}