/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class ike : GComponent
    {
        public GLoader vase;
        public GLoader flower_3;
        public GLoader flower_2;
        public GLoader flower_1;
        public Transition flower_3_effect;
        public Transition flower_2_effect;
        public Transition flower_1_effect;
        public const string URL = "ui://ekoic0wrjfk51yjp7nv";

        public static ike CreateInstance()
        {
            return (ike)UIPackage.CreateObject("fun_CultivationManual_new", "ike");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            vase = (GLoader)GetChildAt(0);
            flower_3 = (GLoader)GetChildAt(1);
            flower_2 = (GLoader)GetChildAt(2);
            flower_1 = (GLoader)GetChildAt(3);
            flower_3_effect = GetTransitionAt(0);
            flower_2_effect = GetTransitionAt(1);
            flower_1_effect = GetTransitionAt(2);
        }
    }
}