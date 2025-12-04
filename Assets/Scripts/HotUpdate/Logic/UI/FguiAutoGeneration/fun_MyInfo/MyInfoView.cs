/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class MyInfoView : GComponent
    {
        public GLoader bg;
        public GImage n37;
        public GImage n12;
        public GImage n5;
        public GImage n19;
        public GImage n11;
        public GComponent head;
        public GComponent frame;
        public GImage vip;
        public GButton editBtn;
        public GButton copyBtn;
        public btn2 btn;
        public probar pro;
        public GTextField poslab;
        public GTextField nameLab;
        public GTextField idLab;
        public GTextField guildLab;
        public GTextField lvLab;
        public GTextField expLab;
        public GGroup n40;
        public GTextField titleLab;
        public btn3 readBtn;
        public btn3 changeBtn;
        public btn3 noticeBtn;
        public GGroup n35;
        public GButton close_btn;
        public btn1 settingBtn;
        public btn1 drawBtn;
        public btn1 storeEarningBtn;
        public GImage n26;
        public showInfoItem flowerNum;
        public showInfoItem flowerLv;
        public showInfoItem group;
        public GGroup n41;
        public GList list;
        public GImage n27;
        public GImage posIMg;
        public GImage n28;
        public GImage n29;
        public GTextField showTitle;
        public GGroup n42;
        public const string URL = "ui://ehkqmfbpiust10";

        public static MyInfoView CreateInstance()
        {
            return (MyInfoView)UIPackage.CreateObject("fun_MyInfo", "MyInfoView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            n37 = (GImage)GetChildAt(1);
            n12 = (GImage)GetChildAt(2);
            n5 = (GImage)GetChildAt(3);
            n19 = (GImage)GetChildAt(4);
            n11 = (GImage)GetChildAt(5);
            head = (GComponent)GetChildAt(6);
            frame = (GComponent)GetChildAt(7);
            vip = (GImage)GetChildAt(8);
            editBtn = (GButton)GetChildAt(9);
            copyBtn = (GButton)GetChildAt(10);
            btn = (btn2)GetChildAt(11);
            pro = (probar)GetChildAt(12);
            poslab = (GTextField)GetChildAt(13);
            nameLab = (GTextField)GetChildAt(14);
            idLab = (GTextField)GetChildAt(15);
            guildLab = (GTextField)GetChildAt(16);
            lvLab = (GTextField)GetChildAt(17);
            expLab = (GTextField)GetChildAt(18);
            n40 = (GGroup)GetChildAt(19);
            titleLab = (GTextField)GetChildAt(20);
            readBtn = (btn3)GetChildAt(21);
            changeBtn = (btn3)GetChildAt(22);
            noticeBtn = (btn3)GetChildAt(23);
            n35 = (GGroup)GetChildAt(24);
            close_btn = (GButton)GetChildAt(25);
            settingBtn = (btn1)GetChildAt(26);
            drawBtn = (btn1)GetChildAt(27);
            storeEarningBtn = (btn1)GetChildAt(28);
            n26 = (GImage)GetChildAt(29);
            flowerNum = (showInfoItem)GetChildAt(30);
            flowerLv = (showInfoItem)GetChildAt(31);
            group = (showInfoItem)GetChildAt(32);
            n41 = (GGroup)GetChildAt(33);
            list = (GList)GetChildAt(34);
            n27 = (GImage)GetChildAt(35);
            posIMg = (GImage)GetChildAt(36);
            n28 = (GImage)GetChildAt(37);
            n29 = (GImage)GetChildAt(38);
            showTitle = (GTextField)GetChildAt(39);
            n42 = (GGroup)GetChildAt(40);
        }
    }
}