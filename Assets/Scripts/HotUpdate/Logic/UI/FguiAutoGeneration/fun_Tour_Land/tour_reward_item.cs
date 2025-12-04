/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Tour_Land
{
    public partial class tour_reward_item : GComponent
    {
        public GLoader bg;
        public GLoader icon;
        public GTextField numLab;
        public const string URL = "ui://oo5kr0yot5nh1r";

        public static tour_reward_item CreateInstance()
        {
            return (tour_reward_item)UIPackage.CreateObject("fun_Tour_Land", "tour_reward_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            icon = (GLoader)GetChildAt(1);
            numLab = (GTextField)GetChildAt(2);
        }
    }
}