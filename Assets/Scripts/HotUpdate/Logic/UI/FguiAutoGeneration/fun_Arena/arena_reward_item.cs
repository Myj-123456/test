/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Arena
{
    public partial class arena_reward_item : GComponent
    {
        public GLoader pic;
        public GTextField txt_num;
        public const string URL = "ui://dz2e3lzav5lj1yjp7vj";

        public static arena_reward_item CreateInstance()
        {
            return (arena_reward_item)UIPackage.CreateObject("fun_Arena", "arena_reward_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            pic = (GLoader)GetChildAt(0);
            txt_num = (GTextField)GetChildAt(1);
        }
    }
}