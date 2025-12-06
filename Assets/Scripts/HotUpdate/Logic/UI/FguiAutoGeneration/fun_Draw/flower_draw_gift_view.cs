/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Draw
{
    public partial class flower_draw_gift_view : GComponent
    {
        public GLoader bg;
        public GImage n2;
        public GImage n3;
        public GTextField tip_lab;
        public GList list;
        public GButton close_btn;
        public const string URL = "ui://97nah3khkeljuu";

        public static flower_draw_gift_view CreateInstance()
        {
            return (flower_draw_gift_view)UIPackage.CreateObject("fun_Draw", "flower_draw_gift_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            n3 = (GImage)GetChildAt(2);
            tip_lab = (GTextField)GetChildAt(3);
            list = (GList)GetChildAt(4);
            close_btn = (GButton)GetChildAt(5);
        }
    }
}