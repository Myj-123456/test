/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivateSeeds
{
    public partial class cultivation_success_view : GComponent
    {
        public Controller share;
        public GLoader n1;
        public GImage n18;
        public GLoader3D spine;
        public GLoader name_bg;
        public GLoader rare_img;
        public GImage n6;
        public GTextField nameLab;
        public GTextField blankLab;
        public GButton btn_back;
        public GButton btn_plant;
        public GImage n9;
        public GTextField tipLab;
        public GButton btn_share;
        public GList list;
        public GTextField shareLab;
        public GGroup n19;
        public const string URL = "ui://udmgdnw2p2vh1ayr877";

        public static cultivation_success_view CreateInstance()
        {
            return (cultivation_success_view)UIPackage.CreateObject("fun_CultivateSeeds", "cultivation_success_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            share = GetControllerAt(0);
            n1 = (GLoader)GetChildAt(0);
            n18 = (GImage)GetChildAt(1);
            spine = (GLoader3D)GetChildAt(2);
            name_bg = (GLoader)GetChildAt(3);
            rare_img = (GLoader)GetChildAt(4);
            n6 = (GImage)GetChildAt(5);
            nameLab = (GTextField)GetChildAt(6);
            blankLab = (GTextField)GetChildAt(7);
            btn_back = (GButton)GetChildAt(8);
            btn_plant = (GButton)GetChildAt(9);
            n9 = (GImage)GetChildAt(10);
            tipLab = (GTextField)GetChildAt(11);
            btn_share = (GButton)GetChildAt(12);
            list = (GList)GetChildAt(13);
            shareLab = (GTextField)GetChildAt(14);
            n19 = (GGroup)GetChildAt(15);
        }
    }
}