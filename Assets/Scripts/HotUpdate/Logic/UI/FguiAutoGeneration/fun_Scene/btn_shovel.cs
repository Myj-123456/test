/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class btn_shovel : GButton
    {
        public GImage n4;
        public GImage n5;
        public GTextField titleLab;
        public const string URL = "ui://dpcxz2finwd51c";

        public static btn_shovel CreateInstance()
        {
            return (btn_shovel)UIPackage.CreateObject("fun_Scene", "btn_shovel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n4 = (GImage)GetChildAt(0);
            n5 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}