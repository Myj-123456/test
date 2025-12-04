/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_Match
{
    public partial class tabBtn : GButton
    {
        public Controller button;
        public GImage n7;
        public GTextField titleLab;
        public GTextField titleLab1;
        public const string URL = "ui://qefze8qir0nz1yjp7vm";

        public static tabBtn CreateInstance()
        {
            return (tabBtn)UIPackage.CreateObject("fun_Guild_Match", "tabBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n7 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
            titleLab1 = (GTextField)GetChildAt(2);
        }
    }
}