/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Pet
{
    public partial class level_info_view : GComponent
    {
        public GLoader3D spine;
        public GImage n1;
        public GImage n2;
        public GImage n5;
        public GImage n18;
        public GImage n19;
        public GImage n20;
        public GImage n21;
        public GTextField curLv;
        public GTextField nextLv;
        public GTextField attackLab;
        public GTextField hpLab;
        public GTextField defenLab;
        public GTextField comboLab;
        public GTextField attackNum;
        public GTextField hpNum;
        public GTextField defenNum;
        public GTextField comboNum;
        public GTextField attackNum1;
        public GTextField hpNum1;
        public GTextField defenNum1;
        public GTextField comboNum1;
        public GImage n23;
        public GImage n25;
        public const string URL = "ui://o7kmyysdx92m2i";

        public static level_info_view CreateInstance()
        {
            return (level_info_view)UIPackage.CreateObject("fun_Pet", "level_info_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            spine = (GLoader3D)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
            n2 = (GImage)GetChildAt(2);
            n5 = (GImage)GetChildAt(3);
            n18 = (GImage)GetChildAt(4);
            n19 = (GImage)GetChildAt(5);
            n20 = (GImage)GetChildAt(6);
            n21 = (GImage)GetChildAt(7);
            curLv = (GTextField)GetChildAt(8);
            nextLv = (GTextField)GetChildAt(9);
            attackLab = (GTextField)GetChildAt(10);
            hpLab = (GTextField)GetChildAt(11);
            defenLab = (GTextField)GetChildAt(12);
            comboLab = (GTextField)GetChildAt(13);
            attackNum = (GTextField)GetChildAt(14);
            hpNum = (GTextField)GetChildAt(15);
            defenNum = (GTextField)GetChildAt(16);
            comboNum = (GTextField)GetChildAt(17);
            attackNum1 = (GTextField)GetChildAt(18);
            hpNum1 = (GTextField)GetChildAt(19);
            defenNum1 = (GTextField)GetChildAt(20);
            comboNum1 = (GTextField)GetChildAt(21);
            n23 = (GImage)GetChildAt(22);
            n25 = (GImage)GetChildAt(23);
        }
    }
}