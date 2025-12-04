/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Tour_Land
{
    public partial class pre_reward_item : GComponent
    {
        public GLoader bg;
        public GLoader icon;
        public GImage n4;
        public GTextField nameLab;
        public GTextField proLab;
        public const string URL = "ui://oo5kr0yot5nh25";

        public static pre_reward_item CreateInstance()
        {
            return (pre_reward_item)UIPackage.CreateObject("fun_Tour_Land", "pre_reward_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            icon = (GLoader)GetChildAt(1);
            n4 = (GImage)GetChildAt(2);
            nameLab = (GTextField)GetChildAt(3);
            proLab = (GTextField)GetChildAt(4);
        }
    }
}