/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_NpcCollection
{
    public partial class npc_collect_item2 : GComponent
    {
        public Controller type;
        public Controller status;
        public GImage n0;
        public GLoader bg;
        public GLoader img;
        public GLoader img1;
        public GTextField name_txt;
        public GTextField task_condition_1;
        public GImage n6;
        public GButton Goto_btn;
        public GButton reward_btn;
        public GImage getted;
        public ProgressBar pro;
        public GTextField Title;
        public const string URL = "ui://ydpeia1vplz71i";

        public static npc_collect_item2 CreateInstance()
        {
            return (npc_collect_item2)UIPackage.CreateObject("fun_NpcCollection", "npc_collect_item2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            status = GetControllerAt(1);
            n0 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            img = (GLoader)GetChildAt(2);
            img1 = (GLoader)GetChildAt(3);
            name_txt = (GTextField)GetChildAt(4);
            task_condition_1 = (GTextField)GetChildAt(5);
            n6 = (GImage)GetChildAt(6);
            Goto_btn = (GButton)GetChildAt(7);
            reward_btn = (GButton)GetChildAt(8);
            getted = (GImage)GetChildAt(9);
            pro = (ProgressBar)GetChildAt(10);
            Title = (GTextField)GetChildAt(11);
        }
    }
}