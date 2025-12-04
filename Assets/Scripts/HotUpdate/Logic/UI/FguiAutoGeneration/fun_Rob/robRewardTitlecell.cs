/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class robRewardTitlecell : GComponent
    {
        public Controller status;
        public GImage n0;
        public GImage n1;
        public GTextField lb_rich;
        public GTextField lb_nomal;
        public const string URL = "ui://z1on8kwdku0fpk9";

        public static robRewardTitlecell CreateInstance()
        {
            return (robRewardTitlecell)UIPackage.CreateObject("fun_Rob", "robRewardTitlecell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n0 = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
            lb_rich = (GTextField)GetChildAt(2);
            lb_nomal = (GTextField)GetChildAt(3);
        }
    }
}