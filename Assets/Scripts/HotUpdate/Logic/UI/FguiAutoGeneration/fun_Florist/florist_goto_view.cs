/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Florist
{
    public partial class florist_goto_view : GComponent
    {
        public GLoader bg;
        public GImage n3;
        public GImage n11;
        public GImage n12;
        public GTextField titleLab;
        public GButton close_btn;
        public GTextField nameLab;
        public GRichTextField proLab;
        public GTextField rewardLab;
        public reward_item item;
        public goto_btn goto_btn;
        public const string URL = "ui://nj16dzxym3ghx";

        public static florist_goto_view CreateInstance()
        {
            return (florist_goto_view)UIPackage.CreateObject("fun_Florist", "florist_goto_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            n3 = (GImage)GetChildAt(1);
            n11 = (GImage)GetChildAt(2);
            n12 = (GImage)GetChildAt(3);
            titleLab = (GTextField)GetChildAt(4);
            close_btn = (GButton)GetChildAt(5);
            nameLab = (GTextField)GetChildAt(6);
            proLab = (GRichTextField)GetChildAt(7);
            rewardLab = (GTextField)GetChildAt(8);
            item = (reward_item)GetChildAt(9);
            goto_btn = (goto_btn)GetChildAt(10);
        }
    }
}