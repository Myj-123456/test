/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_PopTips
{
    public partial class add_tips_view : GComponent
    {
        public Controller status;
        public GLoader bg;
        public GImage n11;
        public add_tips_item video_com;
        public add_tips_item vip_com;
        public GButton close_btn;
        public GTextField titleLab;
        public const string URL = "ui://vhcdvi5tu25ni";

        public static add_tips_view CreateInstance()
        {
            return (add_tips_view)UIPackage.CreateObject("fun_PopTips", "add_tips_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            n11 = (GImage)GetChildAt(1);
            video_com = (add_tips_item)GetChildAt(2);
            vip_com = (add_tips_item)GetChildAt(3);
            close_btn = (GButton)GetChildAt(4);
            titleLab = (GTextField)GetChildAt(5);
        }
    }
}