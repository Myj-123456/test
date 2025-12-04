/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Pet
{
    public partial class pet_main_view : GComponent
    {
        public GLoader bg;
        public GLoader3D spine1;
        public GImage n21;
        public GLoader3D spine2;
        public GImage n26;
        public GImage n27;
        public GImage n28;
        public GImage n29;
        public GImage n30;
        public GImage n31;
        public GImage n9;
        public GLoader call_btn;
        public GImage n13;
        public GImage n14;
        public GTextField tipLab;
        public GLoader3D spine3;
        public Transition anim;
        public const string URL = "ui://o7kmyysdx92m38";

        public static pet_main_view CreateInstance()
        {
            return (pet_main_view)UIPackage.CreateObject("fun_Pet", "pet_main_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            spine1 = (GLoader3D)GetChildAt(1);
            n21 = (GImage)GetChildAt(2);
            spine2 = (GLoader3D)GetChildAt(3);
            n26 = (GImage)GetChildAt(4);
            n27 = (GImage)GetChildAt(5);
            n28 = (GImage)GetChildAt(6);
            n29 = (GImage)GetChildAt(7);
            n30 = (GImage)GetChildAt(8);
            n31 = (GImage)GetChildAt(9);
            n9 = (GImage)GetChildAt(10);
            call_btn = (GLoader)GetChildAt(11);
            n13 = (GImage)GetChildAt(12);
            n14 = (GImage)GetChildAt(13);
            tipLab = (GTextField)GetChildAt(14);
            spine3 = (GLoader3D)GetChildAt(15);
            anim = GetTransitionAt(0);
        }
    }
}