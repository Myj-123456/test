/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MainUI
{
    public partial class bottomBtns : GComponent
    {
        public baihualuBtn btn_baihualu;
        public moreFunUI ui_moreFun;
        public moreBtn btn_moreFun;
        public gmBtn btn_gm;
        public chatUI ui_chat;
        public mian_btn4 btn_friend;
        public mian_btn4 btn_guild;
        public mian_btn4 btn_shop;
        public GGroup show_grp;
        public const string URL = "ui://fa0hi8ybfm3f2r";

        public static bottomBtns CreateInstance()
        {
            return (bottomBtns)UIPackage.CreateObject("fun_MainUI", "bottomBtns");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            btn_baihualu = (baihualuBtn)GetChildAt(0);
            ui_moreFun = (moreFunUI)GetChildAt(1);
            btn_moreFun = (moreBtn)GetChildAt(2);
            btn_gm = (gmBtn)GetChildAt(3);
            ui_chat = (chatUI)GetChildAt(4);
            btn_friend = (mian_btn4)GetChildAt(5);
            btn_guild = (mian_btn4)GetChildAt(6);
            btn_shop = (mian_btn4)GetChildAt(7);
            show_grp = (GGroup)GetChildAt(8);
        }
    }
}