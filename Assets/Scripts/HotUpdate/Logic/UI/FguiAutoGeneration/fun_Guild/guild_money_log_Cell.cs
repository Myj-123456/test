/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guild_money_log_Cell : GComponent
    {
        public Controller genderTab;
        public GImage n21;
        public GImage n23;
        public GTextField txt_userName;
        public GTextField txt_date;
        public GComponent head;
        public GRichTextField txt_info_0;
        public const string URL = "ui://6wv667guerxevgk2t0";

        public static guild_money_log_Cell CreateInstance()
        {
            return (guild_money_log_Cell)UIPackage.CreateObject("fun_Guild", "guild_money_log_Cell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            genderTab = GetControllerAt(0);
            n21 = (GImage)GetChildAt(0);
            n23 = (GImage)GetChildAt(1);
            txt_userName = (GTextField)GetChildAt(2);
            txt_date = (GTextField)GetChildAt(3);
            head = (GComponent)GetChildAt(4);
            txt_info_0 = (GRichTextField)GetChildAt(5);
        }
    }
}