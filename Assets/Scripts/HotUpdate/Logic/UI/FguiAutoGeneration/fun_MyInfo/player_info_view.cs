/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class player_info_view : GComponent
    {
        public Controller status;
        public Controller show;
        public Controller isBlack;
        public GLoader bg;
        public GImage n2;
        public GImage n13;
        public GImage n14;
        public GImage n17;
        public GImage n20;
        public GImage n21;
        public GImage n15;
        public GImage n33;
        public GImage n60;
        public GImage n61;
        public probar1 pro;
        public btn4 dress_btn;
        public GTextField powerNum;
        public GTextField likeLab;
        public GTextField nameLab;
        public GTextField idLab;
        public GTextField guildLab;
        public GTextField id;
        public GTextField guildName;
        public GTextField lvLab;
        public GTextField proLab;
        public GTextField posLab;
        public GLoader3D spine;
        public flower_show_item show_item1;
        public flower_show_item show_item2;
        public flower_show_item show_item3;
        public flower_show_item show_item4;
        public GButton editBtn;
        public GButton copyBtn;
        public GComponent head;
        public GComponent frame;
        public GImage vip;
        public btn2 ope_btn;
        public GGroup n40;
        public btn3 set_btn;
        public btn3 change_btn;
        public btn3 notice_btn;
        public GGroup n41;
        public showInfoItem flower;
        public showInfoItem dress;
        public showInfoItem flowerGod;
        public GButton close_btn;
        public more_com more_com;
        public GButton visit_btn;
        public GButton chat_btn;
        public clickBtn more_btn;
        public GGroup n52;
        public GButton del_black_btn;
        public GButton back_btn;
        public GButton report_btn;
        public GButton add_btn;
        public GGroup n57;
        public GGroup n63;
        public const string URL = "ui://ehkqmfbpj9p61yjp7xh";

        public static player_info_view CreateInstance()
        {
            return (player_info_view)UIPackage.CreateObject("fun_MyInfo", "player_info_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            show = GetControllerAt(1);
            isBlack = GetControllerAt(2);
            bg = (GLoader)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            n13 = (GImage)GetChildAt(2);
            n14 = (GImage)GetChildAt(3);
            n17 = (GImage)GetChildAt(4);
            n20 = (GImage)GetChildAt(5);
            n21 = (GImage)GetChildAt(6);
            n15 = (GImage)GetChildAt(7);
            n33 = (GImage)GetChildAt(8);
            n60 = (GImage)GetChildAt(9);
            n61 = (GImage)GetChildAt(10);
            pro = (probar1)GetChildAt(11);
            dress_btn = (btn4)GetChildAt(12);
            powerNum = (GTextField)GetChildAt(13);
            likeLab = (GTextField)GetChildAt(14);
            nameLab = (GTextField)GetChildAt(15);
            idLab = (GTextField)GetChildAt(16);
            guildLab = (GTextField)GetChildAt(17);
            id = (GTextField)GetChildAt(18);
            guildName = (GTextField)GetChildAt(19);
            lvLab = (GTextField)GetChildAt(20);
            proLab = (GTextField)GetChildAt(21);
            posLab = (GTextField)GetChildAt(22);
            spine = (GLoader3D)GetChildAt(23);
            show_item1 = (flower_show_item)GetChildAt(24);
            show_item2 = (flower_show_item)GetChildAt(25);
            show_item3 = (flower_show_item)GetChildAt(26);
            show_item4 = (flower_show_item)GetChildAt(27);
            editBtn = (GButton)GetChildAt(28);
            copyBtn = (GButton)GetChildAt(29);
            head = (GComponent)GetChildAt(30);
            frame = (GComponent)GetChildAt(31);
            vip = (GImage)GetChildAt(32);
            ope_btn = (btn2)GetChildAt(33);
            n40 = (GGroup)GetChildAt(34);
            set_btn = (btn3)GetChildAt(35);
            change_btn = (btn3)GetChildAt(36);
            notice_btn = (btn3)GetChildAt(37);
            n41 = (GGroup)GetChildAt(38);
            flower = (showInfoItem)GetChildAt(39);
            dress = (showInfoItem)GetChildAt(40);
            flowerGod = (showInfoItem)GetChildAt(41);
            close_btn = (GButton)GetChildAt(42);
            more_com = (more_com)GetChildAt(43);
            visit_btn = (GButton)GetChildAt(44);
            chat_btn = (GButton)GetChildAt(45);
            more_btn = (clickBtn)GetChildAt(46);
            n52 = (GGroup)GetChildAt(47);
            del_black_btn = (GButton)GetChildAt(48);
            back_btn = (GButton)GetChildAt(49);
            report_btn = (GButton)GetChildAt(50);
            add_btn = (GButton)GetChildAt(51);
            n57 = (GGroup)GetChildAt(52);
            n63 = (GGroup)GetChildAt(53);
        }
    }
}