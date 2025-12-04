/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_plant
{
    public partial class unlock_new_farmland : GComponent
    {
        public GLoader bg;
        public GImage n31;
        public GImage n29;
        public GImage n10;
        public GTextField txt_title;
        public GTextField coin_num;
        public GTextField txt_cost;
        public GButton btn_confirm;
        public GButton close_btn;
        public const string URL = "ui://4905g7p7msqb0";

        public static unlock_new_farmland CreateInstance()
        {
            return (unlock_new_farmland)UIPackage.CreateObject("fun_plant", "unlock_new_farmland");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            n31 = (GImage)GetChildAt(1);
            n29 = (GImage)GetChildAt(2);
            n10 = (GImage)GetChildAt(3);
            txt_title = (GTextField)GetChildAt(4);
            coin_num = (GTextField)GetChildAt(5);
            txt_cost = (GTextField)GetChildAt(6);
            btn_confirm = (GButton)GetChildAt(7);
            close_btn = (GButton)GetChildAt(8);
        }
    }
}