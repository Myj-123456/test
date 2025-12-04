/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_NpcOrder
{
    public partial class npc_order : GComponent
    {
        public GLoader3D anim;
        public GLoader bg;
        public GImage n340;
        public GImage n345;
        public GImage n337;
        public GComponent image_flower;
        public GButton btn_back;
        public GButton btn_commit;
        public GButton btn_ike;
        public GTextField txt_name;
        public GImage n342;
        public GImage n328;
        public GTextField txt_OrderReward;
        public GImage n357;
        public GRichTextField txt_have;
        public GList list_npcOrder;
        public GTextField n355;
        public NpcOderPopUp popUp;
        public GList list;
        public const string URL = "ui://asaicjgylyil4";

        public static npc_order CreateInstance()
        {
            return (npc_order)UIPackage.CreateObject("fun_NpcOrder", "npc_order");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            anim = (GLoader3D)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n340 = (GImage)GetChildAt(2);
            n345 = (GImage)GetChildAt(3);
            n337 = (GImage)GetChildAt(4);
            image_flower = (GComponent)GetChildAt(5);
            btn_back = (GButton)GetChildAt(6);
            btn_commit = (GButton)GetChildAt(7);
            btn_ike = (GButton)GetChildAt(8);
            txt_name = (GTextField)GetChildAt(9);
            n342 = (GImage)GetChildAt(10);
            n328 = (GImage)GetChildAt(11);
            txt_OrderReward = (GTextField)GetChildAt(12);
            n357 = (GImage)GetChildAt(13);
            txt_have = (GRichTextField)GetChildAt(14);
            list_npcOrder = (GList)GetChildAt(15);
            n355 = (GTextField)GetChildAt(16);
            popUp = (NpcOderPopUp)GetChildAt(17);
            list = (GList)GetChildAt(18);
        }
    }
}