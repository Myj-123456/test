/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Adventure
{
    public partial class btn : GButton
    {
        public Controller status;
        public GImage n1;
        public GImage n2;
        public GImage n5;
        public GImage n6;
        public GTextField titleLab;
        public const string URL = "ui://3yqg0b4et5nh1f";

        public static btn CreateInstance()
        {
            return (btn)UIPackage.CreateObject("fun_Adventure", "btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            n5 = (GImage)GetChildAt(2);
            n6 = (GImage)GetChildAt(3);
            titleLab = (GTextField)GetChildAt(4);
        }
    }
}