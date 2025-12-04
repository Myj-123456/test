/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual
{
    public partial class greenLongMoneyBtn : GButton
    {
        public Controller button;
        public GImage n10;
        public GLoader pic;
        public GTextField titleLab;
        public GTextField numTxt;
        public const string URL = "ui://6q8q1ai6t77cwprq";

        public static greenLongMoneyBtn CreateInstance()
        {
            return (greenLongMoneyBtn)UIPackage.CreateObject("fun_CultivationManual", "greenLongMoneyBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n10 = (GImage)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
            numTxt = (GTextField)GetChildAt(3);
        }
    }
}