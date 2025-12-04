/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Battle
{
    public partial class SettlementWindow : GComponent
    {
        public Controller c1;
        public GImage n0;
        public GImage n1;
        public GImage n2;
        public GImage n3;
        public GImage n4;
        public GImage n9;
        public GTextField txt_prompt;
        public GList list_reward;
        public SettlementPlayerItem player_me;
        public SettlementPlayerItem player_other;
        public GList list_prompt;
        public GImage n5;
        public GTextField txt_closePrompt;
        public GGroup group_bottom;
        public const string URL = "ui://z1b78orph8da2f";

        public static SettlementWindow CreateInstance()
        {
            return (SettlementWindow)UIPackage.CreateObject("fun_Battle", "SettlementWindow");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            n0 = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
            n2 = (GImage)GetChildAt(2);
            n3 = (GImage)GetChildAt(3);
            n4 = (GImage)GetChildAt(4);
            n9 = (GImage)GetChildAt(5);
            txt_prompt = (GTextField)GetChildAt(6);
            list_reward = (GList)GetChildAt(7);
            player_me = (SettlementPlayerItem)GetChildAt(8);
            player_other = (SettlementPlayerItem)GetChildAt(9);
            list_prompt = (GList)GetChildAt(10);
            n5 = (GImage)GetChildAt(11);
            txt_closePrompt = (GTextField)GetChildAt(12);
            group_bottom = (GGroup)GetChildAt(13);
        }
    }
}