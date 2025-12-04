/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guild_input : GComponent
    {
        public GImage n21;
        public GImage n15;
        public GTextField realTitleLab;
        public GTextField title;
        public GTextInput txt_input;
        public GTextField tip;
        public GButton btn_sure;
        public GButton close_btn;
        public const string URL = "ui://6wv667gutosm1ayr892";

        public static guild_input CreateInstance()
        {
            return (guild_input)UIPackage.CreateObject("fun_Guild", "guild_input");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n21 = (GImage)GetChildAt(0);
            n15 = (GImage)GetChildAt(1);
            realTitleLab = (GTextField)GetChildAt(2);
            title = (GTextField)GetChildAt(3);
            txt_input = (GTextInput)GetChildAt(4);
            tip = (GTextField)GetChildAt(5);
            btn_sure = (GButton)GetChildAt(6);
            close_btn = (GButton)GetChildAt(7);
        }
    }
}