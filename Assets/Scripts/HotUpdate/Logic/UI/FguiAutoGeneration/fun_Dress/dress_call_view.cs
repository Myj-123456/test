/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class dress_call_view : GComponent
    {
        public Controller chose;
        public GLoader bg;
        public probar2 pro;
        public GTextField proLab;
        public GButton one_btn;
        public GButton ten_btn;
        public GList list;
        public GButton close_btn;
        public GGraph get_btn;
        public GButton book_btn;
        public const string URL = "ui://argzn455m3gh1m";

        public static dress_call_view CreateInstance()
        {
            return (dress_call_view)UIPackage.CreateObject("fun_Dress", "dress_call_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            chose = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            pro = (probar2)GetChildAt(1);
            proLab = (GTextField)GetChildAt(2);
            one_btn = (GButton)GetChildAt(3);
            ten_btn = (GButton)GetChildAt(4);
            list = (GList)GetChildAt(5);
            close_btn = (GButton)GetChildAt(6);
            get_btn = (GGraph)GetChildAt(7);
            book_btn = (GButton)GetChildAt(8);
        }
    }
}