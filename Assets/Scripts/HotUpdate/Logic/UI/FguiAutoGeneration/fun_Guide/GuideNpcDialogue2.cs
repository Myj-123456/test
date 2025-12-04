/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guide
{
    public partial class GuideNpcDialogue2 : GComponent
    {
        public GImage n19;
        public GImage n16;
        public GImage n17;
        public GImage n18;
        public GImage n20;
        public GImage n21;
        public GTextField txt_name;
        public GTextField txt_des;
        public GImage n24;
        public const string URL = "ui://miytzucx1003pp";

        public static GuideNpcDialogue2 CreateInstance()
        {
            return (GuideNpcDialogue2)UIPackage.CreateObject("fun_Guide", "GuideNpcDialogue2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n19 = (GImage)GetChildAt(0);
            n16 = (GImage)GetChildAt(1);
            n17 = (GImage)GetChildAt(2);
            n18 = (GImage)GetChildAt(3);
            n20 = (GImage)GetChildAt(4);
            n21 = (GImage)GetChildAt(5);
            txt_name = (GTextField)GetChildAt(6);
            txt_des = (GTextField)GetChildAt(7);
            n24 = (GImage)GetChildAt(8);
        }
    }
}