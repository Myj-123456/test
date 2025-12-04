/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class handbook_brandNew : GComponent
    {
        public Controller pageStatus;
        public GLoader fullScreenBg;
        public bgAnim context;
        public left left;
        public GGroup n132;
        public GImage n110;
        public GTextField titleLab;
        public GButton close_btn;
        public GButton help_btn;
        public const string URL = "ui://ekoic0wriust0";

        public static handbook_brandNew CreateInstance()
        {
            return (handbook_brandNew)UIPackage.CreateObject("fun_CultivationManual_new", "handbook_brandNew");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            pageStatus = GetControllerAt(0);
            fullScreenBg = (GLoader)GetChildAt(0);
            context = (bgAnim)GetChildAt(1);
            left = (left)GetChildAt(2);
            n132 = (GGroup)GetChildAt(3);
            n110 = (GImage)GetChildAt(4);
            titleLab = (GTextField)GetChildAt(5);
            close_btn = (GButton)GetChildAt(6);
            help_btn = (GButton)GetChildAt(7);
        }
    }
}