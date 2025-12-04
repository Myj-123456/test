/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Arena
{
    public partial class arena_battle_view : GComponent
    {
        public GImage n28;
        public GLoader bg;
        public GImage n27;
        public GList list;
        public GButton close_btn;
        public const string URL = "ui://dz2e3lzav5lj2";

        public static arena_battle_view CreateInstance()
        {
            return (arena_battle_view)UIPackage.CreateObject("fun_Arena", "arena_battle_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n28 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n27 = (GImage)GetChildAt(2);
            list = (GList)GetChildAt(3);
            close_btn = (GButton)GetChildAt(4);
        }
    }
}