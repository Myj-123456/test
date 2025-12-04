/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Welfare
{
    public partial class turntable_view : GComponent
    {
        public GLoader bg;
        public turntable_com com;
        public GTextField numLab;
        public GButton get_btn;
        public GGroup n4;
        public const string URL = "ui://awswhm01v01m1yjp845";

        public static turntable_view CreateInstance()
        {
            return (turntable_view)UIPackage.CreateObject("fun_Welfare", "turntable_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            com = (turntable_com)GetChildAt(1);
            numLab = (GTextField)GetChildAt(2);
            get_btn = (GButton)GetChildAt(3);
            n4 = (GGroup)GetChildAt(4);
        }
    }
}