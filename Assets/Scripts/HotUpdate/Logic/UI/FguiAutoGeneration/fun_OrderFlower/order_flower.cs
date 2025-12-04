/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_OrderFlower
{
    public partial class order_flower : GComponent
    {
        public Controller comStatus;
        public GGraph hitArea;
        public GImage n22;
        public GImage n23;
        public GImage n27;
        public GLoader img_flower;
        public GImage n26;
        public GImage n24;
        public GImage n25;
        public GLoader3D spine;
        public GRichTextField lb_flowerName;
        public GRichTextField lb_Complate;
        public GRichTextField txt_have;
        public GGroup n28;
        public GTextField titleLab;
        public GTextField lb_timeDown;
        public GTextField txt_noOrder;
        public GTextField tip_0;
        public com_refresh btn_refresh;
        public GGroup n30;
        public GButton btn_commit;
        public marketReward rewardBoard;
        public GGraph n34;
        public GGroup n35;
        public const string URL = "ui://ypcg4u88u0i39";

        public static order_flower CreateInstance()
        {
            return (order_flower)UIPackage.CreateObject("fun_OrderFlower", "order_flower");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            comStatus = GetControllerAt(0);
            hitArea = (GGraph)GetChildAt(0);
            n22 = (GImage)GetChildAt(1);
            n23 = (GImage)GetChildAt(2);
            n27 = (GImage)GetChildAt(3);
            img_flower = (GLoader)GetChildAt(4);
            n26 = (GImage)GetChildAt(5);
            n24 = (GImage)GetChildAt(6);
            n25 = (GImage)GetChildAt(7);
            spine = (GLoader3D)GetChildAt(8);
            lb_flowerName = (GRichTextField)GetChildAt(9);
            lb_Complate = (GRichTextField)GetChildAt(10);
            txt_have = (GRichTextField)GetChildAt(11);
            n28 = (GGroup)GetChildAt(12);
            titleLab = (GTextField)GetChildAt(13);
            lb_timeDown = (GTextField)GetChildAt(14);
            txt_noOrder = (GTextField)GetChildAt(15);
            tip_0 = (GTextField)GetChildAt(16);
            btn_refresh = (com_refresh)GetChildAt(17);
            n30 = (GGroup)GetChildAt(18);
            btn_commit = (GButton)GetChildAt(19);
            rewardBoard = (marketReward)GetChildAt(20);
            n34 = (GGraph)GetChildAt(21);
            n35 = (GGroup)GetChildAt(22);
        }
    }
}