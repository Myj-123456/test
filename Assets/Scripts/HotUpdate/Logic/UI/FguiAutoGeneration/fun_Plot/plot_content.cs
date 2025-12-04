/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Plot
{
    public partial class plot_content : GComponent
    {
        public GImage n1;
        public GImage n3;
        public GLoader icon;
        public greenPicBtn2 btn;
        public GTextField titleLab;
        public pro_com pro_com;
        public GTextField haveLab;
        public GLoader cost_img;
        public GTextField haveNum;
        public GButton help_btn;
        public GGroup n14;
        public const string URL = "ui://vucpfjl8accs1yjp82u";

        public static plot_content CreateInstance()
        {
            return (plot_content)UIPackage.CreateObject("fun_Plot", "plot_content");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            n3 = (GImage)GetChildAt(1);
            icon = (GLoader)GetChildAt(2);
            btn = (greenPicBtn2)GetChildAt(3);
            titleLab = (GTextField)GetChildAt(4);
            pro_com = (pro_com)GetChildAt(5);
            haveLab = (GTextField)GetChildAt(6);
            cost_img = (GLoader)GetChildAt(7);
            haveNum = (GTextField)GetChildAt(8);
            help_btn = (GButton)GetChildAt(9);
            n14 = (GGroup)GetChildAt(10);
        }
    }
}