/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guild_changeNotice : GComponent
    {
        public GImage n26;
        public GLoader bg;
        public GImage n27;
        public GImage n29;
        public GImage n30;
        public GTextField tip;
        public GTextInput txt_input;
        public GButton btn_sure;
        public GButton close_btn;
        public const string URL = "ui://qz6135j3t5nh1yjp80a";

        public static guild_changeNotice CreateInstance()
        {
            return (guild_changeNotice)UIPackage.CreateObject("fun_Guild_New", "guild_changeNotice");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n26 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n27 = (GImage)GetChildAt(2);
            n29 = (GImage)GetChildAt(3);
            n30 = (GImage)GetChildAt(4);
            tip = (GTextField)GetChildAt(5);
            txt_input = (GTextInput)GetChildAt(6);
            btn_sure = (GButton)GetChildAt(7);
            close_btn = (GButton)GetChildAt(8);
        }
    }
}