/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Welfare
{
    public partial class growth_view : GComponent
    {
        public Controller tab;
        public GLoader bg;
        public GLoader bg1;
        public GLoader flower_img;
        public GLoader bg2;
        public GImage n5;
        public GImage n6;
        public GImage n8;
        public GImage n10;
        public GImage n14;
        public GTextField tipLab;
        public GTextField score_num;
        public GTextField scoreLab;
        public GList page_list;
        public pro1 pro;
        public GGroup n16;
        public GList list;
        public GGraph rect;
        public const string URL = "ui://awswhm01g0s012";

        public static growth_view CreateInstance()
        {
            return (growth_view)UIPackage.CreateObject("fun_Welfare", "growth_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tab = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            bg1 = (GLoader)GetChildAt(1);
            flower_img = (GLoader)GetChildAt(2);
            bg2 = (GLoader)GetChildAt(3);
            n5 = (GImage)GetChildAt(4);
            n6 = (GImage)GetChildAt(5);
            n8 = (GImage)GetChildAt(6);
            n10 = (GImage)GetChildAt(7);
            n14 = (GImage)GetChildAt(8);
            tipLab = (GTextField)GetChildAt(9);
            score_num = (GTextField)GetChildAt(10);
            scoreLab = (GTextField)GetChildAt(11);
            page_list = (GList)GetChildAt(12);
            pro = (pro1)GetChildAt(13);
            n16 = (GGroup)GetChildAt(14);
            list = (GList)GetChildAt(15);
            rect = (GGraph)GetChildAt(16);
        }
    }
}