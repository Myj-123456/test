/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class BestExpView : GComponent
    {
        public GLoader bg;
        public GImage n2;
        public GImage n3;
        public GTextField txt_Title;
        public GTextField title1;
        public GTextField title2;
        public GTextField title3;
        public GButton close_btn;
        public GList list;
        public GTextField txt_desc;
        public const string URL = "ui://fteyf9nzp3vr1yjp7vq";

        public static BestExpView CreateInstance()
        {
            return (BestExpView)UIPackage.CreateObject("fun_Friends", "BestExpView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            n3 = (GImage)GetChildAt(2);
            txt_Title = (GTextField)GetChildAt(3);
            title1 = (GTextField)GetChildAt(4);
            title2 = (GTextField)GetChildAt(5);
            title3 = (GTextField)GetChildAt(6);
            close_btn = (GButton)GetChildAt(7);
            list = (GList)GetChildAt(8);
            txt_desc = (GTextField)GetChildAt(9);
        }
    }
}