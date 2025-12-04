/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_DoubleRevenueByWatchVideo
{
    public partial class VideoPopView : GComponent
    {
        public GImage n1;
        public GImage n2;
        public GLoader3D spnie;
        public GImage n5;
        public GImage n6;
        public GImage n7;
        public GImage n8;
        public GTextField tip1;
        public GTextField tip2;
        public GRichTextField tip3;
        public GButton btn_buy;
        public CloseBtn close_btn;
        public const string URL = "ui://w1i8acwcqhebb";

        public static VideoPopView CreateInstance()
        {
            return (VideoPopView)UIPackage.CreateObject("fun_DoubleRevenueByWatchVideo", "VideoPopView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            spnie = (GLoader3D)GetChildAt(2);
            n5 = (GImage)GetChildAt(3);
            n6 = (GImage)GetChildAt(4);
            n7 = (GImage)GetChildAt(5);
            n8 = (GImage)GetChildAt(6);
            tip1 = (GTextField)GetChildAt(7);
            tip2 = (GTextField)GetChildAt(8);
            tip3 = (GRichTextField)GetChildAt(9);
            btn_buy = (GButton)GetChildAt(10);
            close_btn = (CloseBtn)GetChildAt(11);
        }
    }
}