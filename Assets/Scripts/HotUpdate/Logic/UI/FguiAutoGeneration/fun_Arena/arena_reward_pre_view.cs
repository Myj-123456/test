/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Arena
{
    public partial class arena_reward_pre_view : GComponent
    {
        public GImage n28;
        public GLoader bg;
        public GImage n27;
        public GTextField rewardTipTxt;
        public GList list;
        public GButton close_btn;
        public const string URL = "ui://dz2e3lzav5lj1yjp7vg";

        public static arena_reward_pre_view CreateInstance()
        {
            return (arena_reward_pre_view)UIPackage.CreateObject("fun_Arena", "arena_reward_pre_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n28 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n27 = (GImage)GetChildAt(2);
            rewardTipTxt = (GTextField)GetChildAt(3);
            list = (GList)GetChildAt(4);
            close_btn = (GButton)GetChildAt(5);
        }
    }
}