/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class contractPayWindow : GComponent
    {
        public Controller show;
        public GLoader bg;
        public GImage n77;
        public GImage n78;
        public GImage n79;
        public GTextField tipLab1;
        public GImage n81;
        public GTextField advFlowerNameLab;
        public GImage n83;
        public GTextField superFlowerNameLab;
        public GButton advPayBtn;
        public GButton superPayBtn;
        public GTextField tipLab;
        public GImage n88;
        public GImage n89;
        public GImage n90;
        public GTextField n91;
        public GLoader3D spine1;
        public GLoader3D spine2;
        public contract_text_item gaoji_tipsItem1;
        public contract_text_item gaoji_tipsItem2;
        public contract_text_item gaoji_tipsItem3;
        public contract_text_item gaoji_tipsItem4;
        public GList gaojilist_up;
        public GList gaojilist_down;
        public GImage n101;
        public GImage n102;
        public GTextField n103;
        public contract_text_item zunxiang_tipsItem1;
        public contract_text_item zunxiang_tipsItem2;
        public contract_text_item zunxiang_tipsItem3;
        public contract_text_item zunxiang_tipsItem4;
        public contract_text_item zunxiang_tipsItem4_2;
        public GImage n109;
        public GImage n110;
        public GTextField n111;
        public Transition anim;
        public const string URL = "ui://w3ox9yltm8ja1yjp886";

        public static contractPayWindow CreateInstance()
        {
            return (contractPayWindow)UIPackage.CreateObject("fun_Recharge", "contractPayWindow");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            show = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            n77 = (GImage)GetChildAt(1);
            n78 = (GImage)GetChildAt(2);
            n79 = (GImage)GetChildAt(3);
            tipLab1 = (GTextField)GetChildAt(4);
            n81 = (GImage)GetChildAt(5);
            advFlowerNameLab = (GTextField)GetChildAt(6);
            n83 = (GImage)GetChildAt(7);
            superFlowerNameLab = (GTextField)GetChildAt(8);
            advPayBtn = (GButton)GetChildAt(9);
            superPayBtn = (GButton)GetChildAt(10);
            tipLab = (GTextField)GetChildAt(11);
            n88 = (GImage)GetChildAt(12);
            n89 = (GImage)GetChildAt(13);
            n90 = (GImage)GetChildAt(14);
            n91 = (GTextField)GetChildAt(15);
            spine1 = (GLoader3D)GetChildAt(16);
            spine2 = (GLoader3D)GetChildAt(17);
            gaoji_tipsItem1 = (contract_text_item)GetChildAt(18);
            gaoji_tipsItem2 = (contract_text_item)GetChildAt(19);
            gaoji_tipsItem3 = (contract_text_item)GetChildAt(20);
            gaoji_tipsItem4 = (contract_text_item)GetChildAt(21);
            gaojilist_up = (GList)GetChildAt(22);
            gaojilist_down = (GList)GetChildAt(23);
            n101 = (GImage)GetChildAt(24);
            n102 = (GImage)GetChildAt(25);
            n103 = (GTextField)GetChildAt(26);
            zunxiang_tipsItem1 = (contract_text_item)GetChildAt(27);
            zunxiang_tipsItem2 = (contract_text_item)GetChildAt(28);
            zunxiang_tipsItem3 = (contract_text_item)GetChildAt(29);
            zunxiang_tipsItem4 = (contract_text_item)GetChildAt(30);
            zunxiang_tipsItem4_2 = (contract_text_item)GetChildAt(31);
            n109 = (GImage)GetChildAt(32);
            n110 = (GImage)GetChildAt(33);
            n111 = (GTextField)GetChildAt(34);
            anim = GetTransitionAt(0);
        }
    }
}