/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerOrder
{
    public partial class reward_com : GComponent
    {
        public GLoader img;
        public GTextField numLab;
        public GImage show;
        public GImage n4;
        public GTextField exp_txt_1;
        public GGroup grp;
        public const string URL = "ui://6euywhvrg0s01ayr8fh";

        public static reward_com CreateInstance()
        {
            return (reward_com)UIPackage.CreateObject("fun_FlowerOrder", "reward_com");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            img = (GLoader)GetChildAt(0);
            numLab = (GTextField)GetChildAt(1);
            show = (GImage)GetChildAt(2);
            n4 = (GImage)GetChildAt(3);
            exp_txt_1 = (GTextField)GetChildAt(4);
            grp = (GGroup)GetChildAt(5);
        }
    }
}