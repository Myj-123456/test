/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual
{
    public partial class completeBtn : GButton
    {
        public GImage n14;
        public GLoader pic;
        public GTextField titleLab;
        public GTextField valueLab;
        public const string URL = "ui://6q8q1ai6ftbu1ayr858";

        public static completeBtn CreateInstance()
        {
            return (completeBtn)UIPackage.CreateObject("fun_CultivationManual", "completeBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n14 = (GImage)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
            valueLab = (GTextField)GetChildAt(3);
        }
    }
}