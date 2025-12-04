/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guide
{
    public partial class GuideNpcDialogue : GComponent
    {
        public Controller state;
        public GLoader3D loader_npc;
        public GImage n11;
        public GImage n4;
        public GImage n5;
        public GImage n6;
        public GImage n12;
        public GTextField txt_des;
        public GLoader n7;
        public GImage n10;
        public GTextField txt_name;
        public GGroup group_npc;
        public GLoader clickArea;
        public Transition t0;
        public const string URL = "ui://miytzucx1003pm";

        public static GuideNpcDialogue CreateInstance()
        {
            return (GuideNpcDialogue)UIPackage.CreateObject("fun_Guide", "GuideNpcDialogue");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            state = GetControllerAt(0);
            loader_npc = (GLoader3D)GetChildAt(0);
            n11 = (GImage)GetChildAt(1);
            n4 = (GImage)GetChildAt(2);
            n5 = (GImage)GetChildAt(3);
            n6 = (GImage)GetChildAt(4);
            n12 = (GImage)GetChildAt(5);
            txt_des = (GTextField)GetChildAt(6);
            n7 = (GLoader)GetChildAt(7);
            n10 = (GImage)GetChildAt(8);
            txt_name = (GTextField)GetChildAt(9);
            group_npc = (GGroup)GetChildAt(10);
            clickArea = (GLoader)GetChildAt(11);
            t0 = GetTransitionAt(0);
        }
    }
}