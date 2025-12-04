/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Tour_Land
{
    public partial class pre_reward_view : GComponent
    {
        public GImage n2;
        public GLoader bg;
        public GImage n5;
        public GImage n4;
        public GButton close_btn;
        public GTextField tipLab;
        public GList list;
        public const string URL = "ui://oo5kr0yot5nh22";

        public static pre_reward_view CreateInstance()
        {
            return (pre_reward_view)UIPackage.CreateObject("fun_Tour_Land", "pre_reward_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n2 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n5 = (GImage)GetChildAt(2);
            n4 = (GImage)GetChildAt(3);
            close_btn = (GButton)GetChildAt(4);
            tipLab = (GTextField)GetChildAt(5);
            list = (GList)GetChildAt(6);
        }
    }
}