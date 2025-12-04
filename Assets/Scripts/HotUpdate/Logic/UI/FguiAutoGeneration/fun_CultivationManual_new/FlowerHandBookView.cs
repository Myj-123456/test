/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class FlowerHandBookView : GComponent
    {
        public handbook_brandNew ui;
        public Transition animView;
        public const string URL = "ui://ekoic0wru0i31yjp7u2";

        public static FlowerHandBookView CreateInstance()
        {
            return (FlowerHandBookView)UIPackage.CreateObject("fun_CultivationManual_new", "FlowerHandBookView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            ui = (handbook_brandNew)GetChildAt(0);
            animView = GetTransitionAt(0);
        }
    }
}