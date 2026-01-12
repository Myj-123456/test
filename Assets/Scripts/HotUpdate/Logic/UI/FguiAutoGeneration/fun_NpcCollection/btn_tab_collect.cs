/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_NpcCollection
{
    public partial class btn_tab_collect : GButton
    {
        public Controller button;
        public GImage n3;
        public GImage n4;
        public GTextField titleLab;
        public const string URL = "ui://ydpeia1vplz718";

        public static btn_tab_collect CreateInstance()
        {
            return (btn_tab_collect)UIPackage.CreateObject("fun_NpcCollection", "btn_tab_collect");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n3 = (GImage)GetChildAt(0);
            n4 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}