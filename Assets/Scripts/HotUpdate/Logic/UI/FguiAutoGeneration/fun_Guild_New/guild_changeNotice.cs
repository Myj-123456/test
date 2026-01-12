/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guild_changeNotice : GComponent
    {
        public GLoader bg;
        public GImage n30;
        public GTextField tip;
        public GTextInput txt_input;
        public GButton btn_sure;
        public GButton btn_false;
        public GButton close_btn;
        public GImage n32;
        public GTextField txt_Title;
        public const string URL = "ui://qz6135j3t5nh1yjp80a";

        public static guild_changeNotice CreateInstance()
        {
            return (guild_changeNotice)UIPackage.CreateObject("fun_Guild_New", "guild_changeNotice");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            n30 = (GImage)GetChildAt(1);
            tip = (GTextField)GetChildAt(2);
            txt_input = (GTextInput)GetChildAt(3);
            btn_sure = (GButton)GetChildAt(4);
            btn_false = (GButton)GetChildAt(5);
            close_btn = (GButton)GetChildAt(6);
            n32 = (GImage)GetChildAt(7);
            txt_Title = (GTextField)GetChildAt(8);
        }
    }
}