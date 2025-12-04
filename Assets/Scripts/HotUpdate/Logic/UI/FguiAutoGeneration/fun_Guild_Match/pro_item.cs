/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_Match
{
    public partial class pro_item : GComponent
    {
        public Controller status;
        public Controller show;
        public GImage n1;
        public GImage n5;
        public GImage n7;
        public GImage n9;
        public GImage n6;
        public GImage n8;
        public GTextField proLab;
        public pre_pro_reward reward;
        public const string URL = "ui://qefze8qitewh1";

        public static pro_item CreateInstance()
        {
            return (pro_item)UIPackage.CreateObject("fun_Guild_Match", "pro_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            show = GetControllerAt(1);
            n1 = (GImage)GetChildAt(0);
            n5 = (GImage)GetChildAt(1);
            n7 = (GImage)GetChildAt(2);
            n9 = (GImage)GetChildAt(3);
            n6 = (GImage)GetChildAt(4);
            n8 = (GImage)GetChildAt(5);
            proLab = (GTextField)GetChildAt(6);
            reward = (pre_pro_reward)GetChildAt(7);
        }
    }
}