/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class btn_video : GButton
    {
        public GImage n4;
        public GImage n9;
        public GTextField lb_count;
        public GTextField titleLab;
        public const string URL = "ui://dpcxz2finwd51h";

        public static btn_video CreateInstance()
        {
            return (btn_video)UIPackage.CreateObject("fun_Scene", "btn_video");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n4 = (GImage)GetChildAt(0);
            n9 = (GImage)GetChildAt(1);
            lb_count = (GTextField)GetChildAt(2);
            titleLab = (GTextField)GetChildAt(3);
        }
    }
}