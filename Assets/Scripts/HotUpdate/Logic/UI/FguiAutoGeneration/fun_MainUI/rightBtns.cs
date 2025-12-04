/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MainUI
{
    public partial class rightBtns : GComponent
    {
        public rightBtn_com btn_com;
        public show_btn show_btn;
        public const string URL = "ui://fa0hi8ybu25n1ayr84f";

        public static rightBtns CreateInstance()
        {
            return (rightBtns)UIPackage.CreateObject("fun_MainUI", "rightBtns");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            btn_com = (rightBtn_com)GetChildAt(0);
            show_btn = (show_btn)GetChildAt(1);
        }
    }
}