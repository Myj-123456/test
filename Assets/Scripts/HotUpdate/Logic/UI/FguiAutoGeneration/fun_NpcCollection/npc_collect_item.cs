/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_NpcCollection
{
    public partial class npc_collect_item : GComponent
    {
        public Controller status;
        public Controller isNew;
        public Controller type;
        public GImage n1;
        public GLoader img;
        public GLoader img1;
        public GImage n5;
        public GTextField name_txt;
        public GTextField task_condition_1;
        public GButton reward_btn;
        public GButton getted_btn;
        public GButton exchange_btn;
        public const string URL = "ui://ydpeia1vu0i3b";

        public static npc_collect_item CreateInstance()
        {
            return (npc_collect_item)UIPackage.CreateObject("fun_NpcCollection", "npc_collect_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            isNew = GetControllerAt(1);
            type = GetControllerAt(2);
            n1 = (GImage)GetChildAt(0);
            img = (GLoader)GetChildAt(1);
            img1 = (GLoader)GetChildAt(2);
            n5 = (GImage)GetChildAt(3);
            name_txt = (GTextField)GetChildAt(4);
            task_condition_1 = (GTextField)GetChildAt(5);
            reward_btn = (GButton)GetChildAt(6);
            getted_btn = (GButton)GetChildAt(7);
            exchange_btn = (GButton)GetChildAt(8);
        }
    }
}