/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_plant
{
    public partial class guild_planting_item1 : GComponent
    {
        public GImage n1;
        public guild_player_head head;
        public ui_postion txt_position;
        public GTextField nameLab;
        public GTextField txt_reward;
        public GList reward_list;
        public const string URL = "ui://qfpad3q0tewhq";

        public static guild_planting_item1 CreateInstance()
        {
            return (guild_planting_item1)UIPackage.CreateObject("fun_Guild_plant", "guild_planting_item1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            head = (guild_player_head)GetChildAt(1);
            txt_position = (ui_postion)GetChildAt(2);
            nameLab = (GTextField)GetChildAt(3);
            txt_reward = (GTextField)GetChildAt(4);
            reward_list = (GList)GetChildAt(5);
        }
    }
}