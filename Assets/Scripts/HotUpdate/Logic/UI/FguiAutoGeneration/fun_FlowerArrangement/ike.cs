/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerArrangement
{
    public partial class ike : GComponent
    {
        public Controller state;
        public GLoader vase;
        public GLoader flower_3;
        public GLoader flower_2;
        public GLoader flower_1;
        public GTextField Txt_unlock_lv;
        public GImage n18;
        public GImage n19;
        public GImage n20;
        public GGroup n21;
        public Transition flower_3_effect;
        public Transition flower_2_effect;
        public Transition flower_1_effect;
        public const string URL = "ui://6kofjj39mccn6z";

        public static ike CreateInstance()
        {
            return (ike)UIPackage.CreateObject("fun_FlowerArrangement", "ike");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            state = GetControllerAt(0);
            vase = (GLoader)GetChildAt(0);
            flower_3 = (GLoader)GetChildAt(1);
            flower_2 = (GLoader)GetChildAt(2);
            flower_1 = (GLoader)GetChildAt(3);
            Txt_unlock_lv = (GTextField)GetChildAt(4);
            n18 = (GImage)GetChildAt(5);
            n19 = (GImage)GetChildAt(6);
            n20 = (GImage)GetChildAt(7);
            n21 = (GGroup)GetChildAt(8);
            flower_3_effect = GetTransitionAt(0);
            flower_2_effect = GetTransitionAt(1);
            flower_1_effect = GetTransitionAt(2);
        }
    }
}