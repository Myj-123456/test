/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Draw
{
    public partial class draw_ten_btn : GButton
    {
        public GImage n2;
        public GImage n9;
        public GLoader3D spine;
        public GImage n5;
        public GLoader cost_img;
        public GTextField numLab;
        public const string URL = "ui://97nah3kh11rnuf";

        public static draw_ten_btn CreateInstance()
        {
            return (draw_ten_btn)UIPackage.CreateObject("fun_Draw", "draw_ten_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n2 = (GImage)GetChildAt(0);
            n9 = (GImage)GetChildAt(1);
            spine = (GLoader3D)GetChildAt(2);
            n5 = (GImage)GetChildAt(3);
            cost_img = (GLoader)GetChildAt(4);
            numLab = (GTextField)GetChildAt(5);
        }
    }
}