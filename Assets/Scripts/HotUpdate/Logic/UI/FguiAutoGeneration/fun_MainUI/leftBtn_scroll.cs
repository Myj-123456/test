/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MainUI
{
    public partial class leftBtn_scroll : GComponent
    {
        public Controller status;
        public funLeftBtn btn_vip;
        public funLeftBtn btn_gift;
        public funLeftBtn btn_draw;
        public funLeftBtn btn_match;
        public funLeftBtn btn_active;
        public GGroup btn_grp;
        public const string URL = "ui://fa0hi8ybu25n1ayr84g";

        public static leftBtn_scroll CreateInstance()
        {
            return (leftBtn_scroll)UIPackage.CreateObject("fun_MainUI", "leftBtn_scroll");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            btn_vip = (funLeftBtn)GetChildAt(0);
            btn_gift = (funLeftBtn)GetChildAt(1);
            btn_draw = (funLeftBtn)GetChildAt(2);
            btn_match = (funLeftBtn)GetChildAt(3);
            btn_active = (funLeftBtn)GetChildAt(4);
            btn_grp = (GGroup)GetChildAt(5);
        }
    }
}