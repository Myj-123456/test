/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_OrderFlower
{
    public partial class order_flower : GComponent
    {
        public Controller comStatus;
        public GLoader bg;
        public GImage n43;
        public GImage n39;
        public close_btn close_btn;
        public GLoader img_flower;
        public GRichTextField lb_flowerName;
        public GRichTextField lb_Complate;
        public GRichTextField txt_have;
        public GButton btn_commit;
        public GImage n40;
        public GTextField tip_0;
        public com_refresh btn_refresh;
        public marketReward rewardBoard;
        public GImage n42;
        public GTextField txt_noOrder;
        public GTextField lb_timeDown;
        public const string URL = "ui://ypcg4u88u0i39";

        public static order_flower CreateInstance()
        {
            return (order_flower)UIPackage.CreateObject("fun_OrderFlower", "order_flower");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            comStatus = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            n43 = (GImage)GetChildAt(1);
            n39 = (GImage)GetChildAt(2);
            close_btn = (close_btn)GetChildAt(3);
            img_flower = (GLoader)GetChildAt(4);
            lb_flowerName = (GRichTextField)GetChildAt(5);
            lb_Complate = (GRichTextField)GetChildAt(6);
            txt_have = (GRichTextField)GetChildAt(7);
            btn_commit = (GButton)GetChildAt(8);
            n40 = (GImage)GetChildAt(9);
            tip_0 = (GTextField)GetChildAt(10);
            btn_refresh = (com_refresh)GetChildAt(11);
            rewardBoard = (marketReward)GetChildAt(12);
            n42 = (GImage)GetChildAt(13);
            txt_noOrder = (GTextField)GetChildAt(14);
            lb_timeDown = (GTextField)GetChildAt(15);
        }
    }
}