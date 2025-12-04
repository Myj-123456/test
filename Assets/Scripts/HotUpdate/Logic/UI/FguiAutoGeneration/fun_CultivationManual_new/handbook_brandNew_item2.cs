/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class handbook_brandNew_item2 : GButton
    {
        public Controller status;
        public Controller button;
        public GImage n104;
        public GLoader img1;
        public GTextField name_txt;
        public GImage n108;
        public GImage n14;
        public GImage n107;
        public GImage n109;
        public GTextField limitLab;
        public GGraph rect;
        public const string URL = "ui://ekoic0wrjfk51yjp7y3";

        public static handbook_brandNew_item2 CreateInstance()
        {
            return (handbook_brandNew_item2)UIPackage.CreateObject("fun_CultivationManual_new", "handbook_brandNew_item2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            button = GetControllerAt(1);
            n104 = (GImage)GetChildAt(0);
            img1 = (GLoader)GetChildAt(1);
            name_txt = (GTextField)GetChildAt(2);
            n108 = (GImage)GetChildAt(3);
            n14 = (GImage)GetChildAt(4);
            n107 = (GImage)GetChildAt(5);
            n109 = (GImage)GetChildAt(6);
            limitLab = (GTextField)GetChildAt(7);
            rect = (GGraph)GetChildAt(8);
        }
    }
}