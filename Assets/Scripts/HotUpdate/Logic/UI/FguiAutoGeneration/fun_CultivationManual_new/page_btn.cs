/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class page_btn : GButton
    {
        public Controller button;
        public GImage n17;
        public GImage n18;
        public GTextField titleLab;
        public const string URL = "ui://ekoic0wrp2vh1yjp88z";

        public static page_btn CreateInstance()
        {
            return (page_btn)UIPackage.CreateObject("fun_CultivationManual_new", "page_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n17 = (GImage)GetChildAt(0);
            n18 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}