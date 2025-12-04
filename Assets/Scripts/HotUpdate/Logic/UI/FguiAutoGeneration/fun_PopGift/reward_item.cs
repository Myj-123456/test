/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_PopGift
{
    public partial class reward_item : GComponent
    {
        public GLoader bg;
        public GLoader pic;
        public GTextField countLab;
        public const string URL = "ui://ah12m40ag0s01ayr823";

        public static reward_item CreateInstance()
        {
            return (reward_item)UIPackage.CreateObject("fun_PopGift", "reward_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            countLab = (GTextField)GetChildAt(2);
        }
    }
}