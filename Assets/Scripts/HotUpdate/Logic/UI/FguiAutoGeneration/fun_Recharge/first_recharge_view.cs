/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class first_recharge_view : GComponent
    {
        public Controller tab;
        public Controller buy;
        public Controller unlock;
        public GGraph n26;
        public GImage n59;
        public GLoader3D spine1;
        public GLoader bg;
        public GLoader3D spine;
        public GImage n52;
        public GLoader3D spine2;
        public page_btn2 one_btn;
        public page_btn2 two_btn;
        public page_btn2 three_btn;
        public first_recharge_btn buy_btn1;
        public first_recharge_btn buy_btn2;
        public first_recharge_btn buy_btn3;
        public first_recharge_btn buy_btn4;
        public GTextField tipLab;
        public GList list;
        public first_tip n49;
        public first_tip1 tip_com;
        public first_tip2 name_com;
        public first_btn btn_com;
        public GImage n54;
        public GLoader3D spine3;
        public Transition anim;
        public const string URL = "ui://w3ox9yltdidl25";

        public static first_recharge_view CreateInstance()
        {
            return (first_recharge_view)UIPackage.CreateObject("fun_Recharge", "first_recharge_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tab = GetControllerAt(0);
            buy = GetControllerAt(1);
            unlock = GetControllerAt(2);
            n26 = (GGraph)GetChildAt(0);
            n59 = (GImage)GetChildAt(1);
            spine1 = (GLoader3D)GetChildAt(2);
            bg = (GLoader)GetChildAt(3);
            spine = (GLoader3D)GetChildAt(4);
            n52 = (GImage)GetChildAt(5);
            spine2 = (GLoader3D)GetChildAt(6);
            one_btn = (page_btn2)GetChildAt(7);
            two_btn = (page_btn2)GetChildAt(8);
            three_btn = (page_btn2)GetChildAt(9);
            buy_btn1 = (first_recharge_btn)GetChildAt(10);
            buy_btn2 = (first_recharge_btn)GetChildAt(11);
            buy_btn3 = (first_recharge_btn)GetChildAt(12);
            buy_btn4 = (first_recharge_btn)GetChildAt(13);
            tipLab = (GTextField)GetChildAt(14);
            list = (GList)GetChildAt(15);
            n49 = (first_tip)GetChildAt(16);
            tip_com = (first_tip1)GetChildAt(17);
            name_com = (first_tip2)GetChildAt(18);
            btn_com = (first_btn)GetChildAt(19);
            n54 = (GImage)GetChildAt(20);
            spine3 = (GLoader3D)GetChildAt(21);
            anim = GetTransitionAt(0);
        }
    }
}