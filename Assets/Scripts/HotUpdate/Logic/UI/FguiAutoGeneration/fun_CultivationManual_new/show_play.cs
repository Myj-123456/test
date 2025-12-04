/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class show_play : GComponent
    {
        public GGraph n0;
        public GImage n2;
        public Transition anim;
        public const string URL = "ui://ekoic0wrq9bj1yjp7u9";

        public static show_play CreateInstance()
        {
            return (show_play)UIPackage.CreateObject("fun_CultivationManual_new", "show_play");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GGraph)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            anim = GetTransitionAt(0);
        }
    }
}