/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MainUI
{
    public partial class leftBtns : GComponent
    {
        public leftBtn_com btn;
        public show_btn show_btn;
        public const string URL = "ui://fa0hi8ybu25n1ayr84c";

        public static leftBtns CreateInstance()
        {
            return (leftBtns)UIPackage.CreateObject("fun_MainUI", "leftBtns");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            btn = (leftBtn_com)GetChildAt(0);
            show_btn = (show_btn)GetChildAt(1);
        }
    }
}