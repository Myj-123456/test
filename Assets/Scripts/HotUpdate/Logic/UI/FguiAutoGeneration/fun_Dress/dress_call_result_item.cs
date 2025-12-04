/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class dress_call_result_item : GComponent
    {
        public Controller have;
        public Controller status;
        public GLoader icon;
        public GLoader bg;
        public GLoader rare_img;
        public GImage n17;
        public GTextField nameLab;
        public GTextField haveLab;
        public GButton detail_btn;
        public const string URL = "ui://argzn455m3gh4y";

        public static dress_call_result_item CreateInstance()
        {
            return (dress_call_result_item)UIPackage.CreateObject("fun_Dress", "dress_call_result_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            have = GetControllerAt(0);
            status = GetControllerAt(1);
            icon = (GLoader)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            rare_img = (GLoader)GetChildAt(2);
            n17 = (GImage)GetChildAt(3);
            nameLab = (GTextField)GetChildAt(4);
            haveLab = (GTextField)GetChildAt(5);
            detail_btn = (GButton)GetChildAt(6);
        }
    }
}