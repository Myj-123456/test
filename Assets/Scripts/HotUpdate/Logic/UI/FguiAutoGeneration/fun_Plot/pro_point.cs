/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Plot
{
    public partial class pro_point : GComponent
    {
        public Controller type;
        public Controller show;
        public GImage n0;
        public GImage n1;
        public GImage n2;
        public reward_box box;
        public const string URL = "ui://vucpfjl8accs1yjp83c";

        public static pro_point CreateInstance()
        {
            return (pro_point)UIPackage.CreateObject("fun_Plot", "pro_point");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            show = GetControllerAt(1);
            n0 = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
            n2 = (GImage)GetChildAt(2);
            box = (reward_box)GetChildAt(3);
        }
    }
}