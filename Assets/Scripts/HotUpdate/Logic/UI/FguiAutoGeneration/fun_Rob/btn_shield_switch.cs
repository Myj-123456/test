/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class btn_shield_switch : GComponent
    {
        public Controller status;
        public GImage n0;
        public GImage n1;
        public const string URL = "ui://z1on8kwdq1bopm1";

        public static btn_shield_switch CreateInstance()
        {
            return (btn_shield_switch)UIPackage.CreateObject("fun_Rob", "btn_shield_switch");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n0 = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
        }
    }
}