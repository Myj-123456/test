/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Florist
{
    public partial class level_view : GComponent
    {
        public Controller max;
        public GLoader bg;
        public GLoader pic;
        public GImage n30;
        public GImage n31;
        public GImage n32;
        public GImage n6;
        public GImage n7;
        public GTextField lvLab;
        public GTextField curLv;
        public GTextField nextLv;
        public GTextField deskLimit;
        public GTextField curDesk;
        public GTextField nextDesk;
        public GTextField flowerLimit;
        public GTextField curFlower;
        public GTextField nextFlower;
        public GGroup n33;
        public GImage n0;
        public GImage n1;
        public GImage n2;
        public GTextField rewardLab;
        public GList reward_list;
        public GGroup n34;
        public GButton levelUp_btn;
        public GImage n3;
        public GImage n4;
        public GImage n5;
        public GTextField limitLab;
        public limit_com limitCom;
        public GGroup n38;
        public const string URL = "ui://nj16dzxym3gh6";

        public static level_view CreateInstance()
        {
            return (level_view)UIPackage.CreateObject("fun_Florist", "level_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            max = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            n30 = (GImage)GetChildAt(2);
            n31 = (GImage)GetChildAt(3);
            n32 = (GImage)GetChildAt(4);
            n6 = (GImage)GetChildAt(5);
            n7 = (GImage)GetChildAt(6);
            lvLab = (GTextField)GetChildAt(7);
            curLv = (GTextField)GetChildAt(8);
            nextLv = (GTextField)GetChildAt(9);
            deskLimit = (GTextField)GetChildAt(10);
            curDesk = (GTextField)GetChildAt(11);
            nextDesk = (GTextField)GetChildAt(12);
            flowerLimit = (GTextField)GetChildAt(13);
            curFlower = (GTextField)GetChildAt(14);
            nextFlower = (GTextField)GetChildAt(15);
            n33 = (GGroup)GetChildAt(16);
            n0 = (GImage)GetChildAt(17);
            n1 = (GImage)GetChildAt(18);
            n2 = (GImage)GetChildAt(19);
            rewardLab = (GTextField)GetChildAt(20);
            reward_list = (GList)GetChildAt(21);
            n34 = (GGroup)GetChildAt(22);
            levelUp_btn = (GButton)GetChildAt(23);
            n3 = (GImage)GetChildAt(24);
            n4 = (GImage)GetChildAt(25);
            n5 = (GImage)GetChildAt(26);
            limitLab = (GTextField)GetChildAt(27);
            limitCom = (limit_com)GetChildAt(28);
            n38 = (GGroup)GetChildAt(29);
        }
    }
}