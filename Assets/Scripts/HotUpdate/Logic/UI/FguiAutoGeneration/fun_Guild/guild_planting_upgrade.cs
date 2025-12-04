/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guild_planting_upgrade : GComponent
    {
        public GImage bg;
        public GImage n1;
        public GImage n34;
        public GTextField realTitleLab;
        public GTextField titleTxt;
        public GList list;
        public GuildFlowerpotFeature nextFeature;
        public GuildFlowerpotFeature curFeature;
        public GButton upgradeBtn;
        public GButton close_btn;
        public const string URL = "ui://6wv667gugtac1ayr899";

        public static guild_planting_upgrade CreateInstance()
        {
            return (guild_planting_upgrade)UIPackage.CreateObject("fun_Guild", "guild_planting_upgrade");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
            n34 = (GImage)GetChildAt(2);
            realTitleLab = (GTextField)GetChildAt(3);
            titleTxt = (GTextField)GetChildAt(4);
            list = (GList)GetChildAt(5);
            nextFeature = (GuildFlowerpotFeature)GetChildAt(6);
            curFeature = (GuildFlowerpotFeature)GetChildAt(7);
            upgradeBtn = (GButton)GetChildAt(8);
            close_btn = (GButton)GetChildAt(9);
        }
    }
}