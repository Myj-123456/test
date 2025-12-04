/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class vase_item : GButton
    {
        public Controller button;
        public Controller type;
        public Controller unlock;
        public GComponent ike;
        public GImage n2;
        public GLoader get_btn;
        public GImage n4;
        public Transition anim;
        public const string URL = "ui://ekoic0wrjfk51yjp7y0";

        public static vase_item CreateInstance()
        {
            return (vase_item)UIPackage.CreateObject("fun_CultivationManual_new", "vase_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            type = GetControllerAt(1);
            unlock = GetControllerAt(2);
            ike = (GComponent)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            get_btn = (GLoader)GetChildAt(2);
            n4 = (GImage)GetChildAt(3);
            anim = GetTransitionAt(0);
        }
    }
}