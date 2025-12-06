/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Draw
{
    public partial class daimond_draw_btn : GComponent
    {
        public Controller type;
        public GButton one_btn;
        public GButton ten_btn;
        public GImage n4;
        public GLoader cost_img;
        public GTextField numLab;
        public const string URL = "ui://97nah3khkeljvk";

        public static daimond_draw_btn CreateInstance()
        {
            return (daimond_draw_btn)UIPackage.CreateObject("fun_Draw", "daimond_draw_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            one_btn = (GButton)GetChildAt(0);
            ten_btn = (GButton)GetChildAt(1);
            n4 = (GImage)GetChildAt(2);
            cost_img = (GLoader)GetChildAt(3);
            numLab = (GTextField)GetChildAt(4);
        }
    }
}