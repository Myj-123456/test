/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class btn_videos : GButton
    {
        public GImage n4;
        public GImage n5;
        public GImage n6;
        public GTextField titleLab;
        public GTextField txt_number;
        public GTextField reward_num;
        public GLoader pic;
        public const string URL = "ui://z1on8kwdcw741ayr8mg";

        public static btn_videos CreateInstance()
        {
            return (btn_videos)UIPackage.CreateObject("fun_Rob", "btn_videos");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n4 = (GImage)GetChildAt(0);
            n5 = (GImage)GetChildAt(1);
            n6 = (GImage)GetChildAt(2);
            titleLab = (GTextField)GetChildAt(3);
            txt_number = (GTextField)GetChildAt(4);
            reward_num = (GTextField)GetChildAt(5);
            pic = (GLoader)GetChildAt(6);
        }
    }
}