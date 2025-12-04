/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MainUI
{
    public partial class moreFunUI : GComponent
    {
        public GImage n20;
        public mian_btn1 btn_dress;
        public cultivationShopBtn btn_room;
        public mian_btn2 btn_role;
        public mian_btn2 btn_achieve;
        public mian_btn2 btn_book;
        public mian_btn2 btn_pet;
        public mian_btn2 btn_flower_gold;
        public mian_btn2 btn_dailyTask;
        public mian_btn2 btn_storage;
        public mian_btn1 btn_rank;
        public GButton btn_mail;
        public GButton btn_notice;
        public GButton btn_store;
        public GButton btn_photo;
        public const string URL = "ui://fa0hi8ybn88p3i";

        public static moreFunUI CreateInstance()
        {
            return (moreFunUI)UIPackage.CreateObject("fun_MainUI", "moreFunUI");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n20 = (GImage)GetChildAt(0);
            btn_dress = (mian_btn1)GetChildAt(1);
            btn_room = (cultivationShopBtn)GetChildAt(2);
            btn_role = (mian_btn2)GetChildAt(3);
            btn_achieve = (mian_btn2)GetChildAt(4);
            btn_book = (mian_btn2)GetChildAt(5);
            btn_pet = (mian_btn2)GetChildAt(6);
            btn_flower_gold = (mian_btn2)GetChildAt(7);
            btn_dailyTask = (mian_btn2)GetChildAt(8);
            btn_storage = (mian_btn2)GetChildAt(9);
            btn_rank = (mian_btn1)GetChildAt(10);
            btn_mail = (GButton)GetChildAt(11);
            btn_notice = (GButton)GetChildAt(12);
            btn_store = (GButton)GetChildAt(13);
            btn_photo = (GButton)GetChildAt(14);
        }
    }
}