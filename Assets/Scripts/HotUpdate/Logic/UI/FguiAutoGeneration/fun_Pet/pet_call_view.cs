/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Pet
{
    public partial class pet_call_view : GComponent
    {
        public GLoader bg;
        public GImage n5;
        public GTextField titleLab;
        public GButton help_btn;
        public pet_call_show com;
        public GButton close_btn;
        public btn2 get_btn;
        public const string URL = "ui://o7kmyysdx92m29";

        public static pet_call_view CreateInstance()
        {
            return (pet_call_view)UIPackage.CreateObject("fun_Pet", "pet_call_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            n5 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
            help_btn = (GButton)GetChildAt(3);
            com = (pet_call_show)GetChildAt(4);
            close_btn = (GButton)GetChildAt(5);
            get_btn = (btn2)GetChildAt(6);
        }
    }
}