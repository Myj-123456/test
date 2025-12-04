/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class chose_back_view : GComponent
    {
        public GImage n2;
        public GLoader bg;
        public GImage n3;
        public GButton close_btn;
        public GList list;
        public const string URL = "ui://argzn455xc4q1yjp82i";

        public static chose_back_view CreateInstance()
        {
            return (chose_back_view)UIPackage.CreateObject("fun_Dress", "chose_back_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n2 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n3 = (GImage)GetChildAt(2);
            close_btn = (GButton)GetChildAt(3);
            list = (GList)GetChildAt(4);
        }
    }
}