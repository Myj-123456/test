/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class lockBtn : GButton
    {
        public GImage n9;
        public GLoader pic;
        public GTextField titleLab;
        public GTextField valueLab;
        public const string URL = "ui://ekoic0wrqheb1yjp7un";

        public static lockBtn CreateInstance()
        {
            return (lockBtn)UIPackage.CreateObject("fun_CultivationManual_new", "lockBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n9 = (GImage)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
            valueLab = (GTextField)GetChildAt(3);
        }
    }
}