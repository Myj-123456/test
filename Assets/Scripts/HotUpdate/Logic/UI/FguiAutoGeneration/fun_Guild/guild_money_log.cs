/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guild_money_log : GComponent
    {
        public GImage n15;
        public GButton close_btn;
        public GRichTextField lb_title;
        public GRichTextField lb_tip;
        public GList ls_message;
        public const string URL = "ui://6wv667guerxevgk2sz";

        public static guild_money_log CreateInstance()
        {
            return (guild_money_log)UIPackage.CreateObject("fun_Guild", "guild_money_log");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n15 = (GImage)GetChildAt(0);
            close_btn = (GButton)GetChildAt(1);
            lb_title = (GRichTextField)GetChildAt(2);
            lb_tip = (GRichTextField)GetChildAt(3);
            ls_message = (GList)GetChildAt(4);
        }
    }
}