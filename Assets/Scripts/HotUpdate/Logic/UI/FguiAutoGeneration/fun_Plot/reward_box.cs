/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Plot
{
    public partial class reward_box : GButton
    {
        public Controller status;
        public GImage n1;
        public GImage n2;
        public GImage n3;
        public GTextField titleLab;
        public const string URL = "ui://vucpfjl8accs1yjp82x";

        public static reward_box CreateInstance()
        {
            return (reward_box)UIPackage.CreateObject("fun_Plot", "reward_box");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            n3 = (GImage)GetChildAt(2);
            titleLab = (GTextField)GetChildAt(3);
        }
    }
}