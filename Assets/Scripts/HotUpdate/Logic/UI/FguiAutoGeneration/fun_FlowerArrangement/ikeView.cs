/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerArrangement
{
    public partial class ikeView : GComponent
    {
        public Controller showFlower;
        public Controller type;
        public Controller unlock;
        public GLoader bg;
        public GImage n340;
        public GLoader3D loader_spine;
        public GImage n326;
        public GImage n322;
        public ike ike;
        public GImage n320;
        public GTextField txt_price;
        public GTextField Txt_gold;
        public GGroup priceGp;
        public GButton btn_right;
        public GButton btn_left;
        public GTextField txt_num;
        public GGraph input_area;
        public GButton btn_add;
        public GButton btn_minus;
        public tweenCom tweenCom;
        public GGroup n357;
        public GButton help_btn;
        public GButton close_btn;
        public GTextField titleLab;
        public GImage n344;
        public materialListNew materialList;
        public GRichTextField tip;
        public GGroup showNeed;
        public GImage n348;
        public GButton btn_make;
        public add btn_select_1;
        public add btn_select_2;
        public add btn_select_3;
        public GGroup btn_select;
        public GGroup n351;
        public const string URL = "ui://6kofjj39lmjv1yjp7my";

        public static ikeView CreateInstance()
        {
            return (ikeView)UIPackage.CreateObject("fun_FlowerArrangement", "ikeView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            showFlower = GetControllerAt(0);
            type = GetControllerAt(1);
            unlock = GetControllerAt(2);
            bg = (GLoader)GetChildAt(0);
            n340 = (GImage)GetChildAt(1);
            loader_spine = (GLoader3D)GetChildAt(2);
            n326 = (GImage)GetChildAt(3);
            n322 = (GImage)GetChildAt(4);
            ike = (ike)GetChildAt(5);
            n320 = (GImage)GetChildAt(6);
            txt_price = (GTextField)GetChildAt(7);
            Txt_gold = (GTextField)GetChildAt(8);
            priceGp = (GGroup)GetChildAt(9);
            btn_right = (GButton)GetChildAt(10);
            btn_left = (GButton)GetChildAt(11);
            txt_num = (GTextField)GetChildAt(12);
            input_area = (GGraph)GetChildAt(13);
            btn_add = (GButton)GetChildAt(14);
            btn_minus = (GButton)GetChildAt(15);
            tweenCom = (tweenCom)GetChildAt(16);
            n357 = (GGroup)GetChildAt(17);
            help_btn = (GButton)GetChildAt(18);
            close_btn = (GButton)GetChildAt(19);
            titleLab = (GTextField)GetChildAt(20);
            n344 = (GImage)GetChildAt(21);
            materialList = (materialListNew)GetChildAt(22);
            tip = (GRichTextField)GetChildAt(23);
            showNeed = (GGroup)GetChildAt(24);
            n348 = (GImage)GetChildAt(25);
            btn_make = (GButton)GetChildAt(26);
            btn_select_1 = (add)GetChildAt(27);
            btn_select_2 = (add)GetChildAt(28);
            btn_select_3 = (add)GetChildAt(29);
            btn_select = (GGroup)GetChildAt(30);
            n351 = (GGroup)GetChildAt(31);
        }
    }
}