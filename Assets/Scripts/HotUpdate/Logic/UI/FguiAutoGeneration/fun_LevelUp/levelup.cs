/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_LevelUp
{
    public partial class levelup : GComponent
    {
        public GLoader3D spine;
        public GTextField level_txt;
        public GImage n17;
        public GButton share_btn;
        public Transition anim;
        public const string URL = "ui://zxpmd1qwqheb1ayr8be";

        public static levelup CreateInstance()
        {
            return (levelup)UIPackage.CreateObject("fun_LevelUp", "levelup");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            spine = (GLoader3D)GetChildAt(0);
            level_txt = (GTextField)GetChildAt(1);
            n17 = (GImage)GetChildAt(2);
            share_btn = (GButton)GetChildAt(3);
            anim = GetTransitionAt(0);
        }
    }
}