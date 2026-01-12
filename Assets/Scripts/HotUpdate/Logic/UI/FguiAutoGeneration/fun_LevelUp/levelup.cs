/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_LevelUp
{
    public partial class levelup : GComponent
    {
        public GLoader3D spine;
        public GImage n39;
        public GImage n27;
        public GTextField level_txt;
        public GImage n21;
        public GImage n38;
        public GImage n28;
        public GImage n29;
        public GTextField title1;
        public GImage n31;
        public GImage n32;
        public GTextField title2;
        public GButton share_btn;
        public GList list;
        public GList list2;
        public GTextField close_btn;
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
            n39 = (GImage)GetChildAt(1);
            n27 = (GImage)GetChildAt(2);
            level_txt = (GTextField)GetChildAt(3);
            n21 = (GImage)GetChildAt(4);
            n38 = (GImage)GetChildAt(5);
            n28 = (GImage)GetChildAt(6);
            n29 = (GImage)GetChildAt(7);
            title1 = (GTextField)GetChildAt(8);
            n31 = (GImage)GetChildAt(9);
            n32 = (GImage)GetChildAt(10);
            title2 = (GTextField)GetChildAt(11);
            share_btn = (GButton)GetChildAt(12);
            list = (GList)GetChildAt(13);
            list2 = (GList)GetChildAt(14);
            close_btn = (GTextField)GetChildAt(15);
            anim = GetTransitionAt(0);
        }
    }
}