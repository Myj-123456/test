/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class unlock_new_farmland : GComponent
    {
        public GLoader bg;
        public GImage n40;
        public GButton close_btn;
        public GImage n43;
        public GButton btn_confirm;
        public GImage n45;
        public GImage n46;
        public GTextField txt_hint;
        public GTextField txt_cost;
        public GImage n48;
        public GTextField coin_num;
        public GGroup n49;
        public const string URL = "ui://dpcxz2fimsqb0";

        public static unlock_new_farmland CreateInstance()
        {
            return (unlock_new_farmland)UIPackage.CreateObject("fun_Scene", "unlock_new_farmland");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            n40 = (GImage)GetChildAt(1);
            close_btn = (GButton)GetChildAt(2);
            n43 = (GImage)GetChildAt(3);
            btn_confirm = (GButton)GetChildAt(4);
            n45 = (GImage)GetChildAt(5);
            n46 = (GImage)GetChildAt(6);
            txt_hint = (GTextField)GetChildAt(7);
            txt_cost = (GTextField)GetChildAt(8);
            n48 = (GImage)GetChildAt(9);
            coin_num = (GTextField)GetChildAt(10);
            n49 = (GGroup)GetChildAt(11);
        }
    }
}