/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guild_manage : GComponent
    {
        public GLoader bg;
        public GImage n69;
        public GImage n61;
        public GImage n65;
        public GImage n66;
        public GImage n67;
        public GList list_positionName;
        public order_progress progress;
        public GImage n42;
        public GTextField txt_lv;
        public GTextField txt_money;
        public GTextField txt_title_manage;
        public GRichTextField txt_title_posName;
        public GButton btn_max;
        public guildUpLvBtn btn_upgrade;
        public GButton close_btn;
        public const string URL = "ui://6wv667gugtac1ayr893";

        public static guild_manage CreateInstance()
        {
            return (guild_manage)UIPackage.CreateObject("fun_Guild", "guild_manage");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            n69 = (GImage)GetChildAt(1);
            n61 = (GImage)GetChildAt(2);
            n65 = (GImage)GetChildAt(3);
            n66 = (GImage)GetChildAt(4);
            n67 = (GImage)GetChildAt(5);
            list_positionName = (GList)GetChildAt(6);
            progress = (order_progress)GetChildAt(7);
            n42 = (GImage)GetChildAt(8);
            txt_lv = (GTextField)GetChildAt(9);
            txt_money = (GTextField)GetChildAt(10);
            txt_title_manage = (GTextField)GetChildAt(11);
            txt_title_posName = (GRichTextField)GetChildAt(12);
            btn_max = (GButton)GetChildAt(13);
            btn_upgrade = (guildUpLvBtn)GetChildAt(14);
            close_btn = (GButton)GetChildAt(15);
        }
    }
}