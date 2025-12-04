/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guild_planting : GComponent
    {
        public Controller pageTab;
        public GImage n70;
        public GTextField titleTxt;
        public GImage n60;
        public GImage n61;
        public GList list;
        public GButton getBtn;
        public GImage n68;
        public GTextField guildMoneyTxt;
        public GLoader moneyIcon;
        public GTextField tipTxt;
        public GButton close_btn;
        public GButton question_btn;
        public GButton leftBtn;
        public GButton rightBtn;
        public const string URL = "ui://6wv667guhxk4pgt";

        public static guild_planting CreateInstance()
        {
            return (guild_planting)UIPackage.CreateObject("fun_Guild", "guild_planting");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            pageTab = GetControllerAt(0);
            n70 = (GImage)GetChildAt(0);
            titleTxt = (GTextField)GetChildAt(1);
            n60 = (GImage)GetChildAt(2);
            n61 = (GImage)GetChildAt(3);
            list = (GList)GetChildAt(4);
            getBtn = (GButton)GetChildAt(5);
            n68 = (GImage)GetChildAt(6);
            guildMoneyTxt = (GTextField)GetChildAt(7);
            moneyIcon = (GLoader)GetChildAt(8);
            tipTxt = (GTextField)GetChildAt(9);
            close_btn = (GButton)GetChildAt(10);
            question_btn = (GButton)GetChildAt(11);
            leftBtn = (GButton)GetChildAt(12);
            rightBtn = (GButton)GetChildAt(13);
        }
    }
}