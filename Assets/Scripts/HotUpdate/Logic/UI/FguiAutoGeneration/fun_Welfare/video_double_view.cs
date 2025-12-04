/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Welfare
{
    public partial class video_double_view : GComponent
    {
        public GLoader bg;
        public GLoader3D spnie;
        public GTextField tip1;
        public GTextField tip2;
        public GRichTextField tip3;
        public GButton btn_buy;
        public GTextField timeLab;
        public GGroup n19;
        public const string URL = "ui://awswhm01s7sl1yjp7vc";

        public static video_double_view CreateInstance()
        {
            return (video_double_view)UIPackage.CreateObject("fun_Welfare", "video_double_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            spnie = (GLoader3D)GetChildAt(1);
            tip1 = (GTextField)GetChildAt(2);
            tip2 = (GTextField)GetChildAt(3);
            tip3 = (GRichTextField)GetChildAt(4);
            btn_buy = (GButton)GetChildAt(5);
            timeLab = (GTextField)GetChildAt(6);
            n19 = (GGroup)GetChildAt(7);
        }
    }
}