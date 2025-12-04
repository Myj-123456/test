/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guild_upgrade_confirm : GComponent
    {
        public GImage n32;
        public GImage n27;
        public GTextField realTitleLab;
        public GTextField txt_desc_title;
        public GTextField txt_title;
        public GTextField descLab1;
        public GTextField descLab2;
        public GList list_desc;
        public GButton btn_sure;
        public GButton btn_cancel;
        public GImage n31;
        public const string URL = "ui://6wv667gugtac1ayr898";

        public static guild_upgrade_confirm CreateInstance()
        {
            return (guild_upgrade_confirm)UIPackage.CreateObject("fun_Guild", "guild_upgrade_confirm");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n32 = (GImage)GetChildAt(0);
            n27 = (GImage)GetChildAt(1);
            realTitleLab = (GTextField)GetChildAt(2);
            txt_desc_title = (GTextField)GetChildAt(3);
            txt_title = (GTextField)GetChildAt(4);
            descLab1 = (GTextField)GetChildAt(5);
            descLab2 = (GTextField)GetChildAt(6);
            list_desc = (GList)GetChildAt(7);
            btn_sure = (GButton)GetChildAt(8);
            btn_cancel = (GButton)GetChildAt(9);
            n31 = (GImage)GetChildAt(10);
        }
    }
}