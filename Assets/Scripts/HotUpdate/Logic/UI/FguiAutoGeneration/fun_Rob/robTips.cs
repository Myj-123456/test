/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class robTips : GComponent
    {
        public GImage n0;
        public GRichTextField lb_info;
        public const string URL = "ui://z1on8kwdckwypky";

        public static robTips CreateInstance()
        {
            return (robTips)UIPackage.CreateObject("fun_Rob", "robTips");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            lb_info = (GRichTextField)GetChildAt(1);
        }
    }
}