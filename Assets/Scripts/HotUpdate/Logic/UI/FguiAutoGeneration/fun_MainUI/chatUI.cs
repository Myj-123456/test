/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MainUI
{
    public partial class chatUI : GComponent
    {
        public GImage n4;
        public GImage n5;
        public GTextField world_lab;
        public GRichTextField chatLab;
        public const string URL = "ui://fa0hi8ybr61w3l";

        public static chatUI CreateInstance()
        {
            return (chatUI)UIPackage.CreateObject("fun_MainUI", "chatUI");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n4 = (GImage)GetChildAt(0);
            n5 = (GImage)GetChildAt(1);
            world_lab = (GTextField)GetChildAt(2);
            chatLab = (GRichTextField)GetChildAt(3);
        }
    }
}