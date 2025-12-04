/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class guild_input : GComponent
    {
        public GImage n14;
        public GLoader bg;
        public GImage n18;
        public GImage n19;
        public CloseBtn_1 close_btn;
        public GTextInput txt_input;
        public clickBtn1 btn_sure;
        public GImage n15;
        public GImage n16;
        public GTextField title;
        public const string URL = "ui://mjiw43v9tosm1yjp7sl";

        public static guild_input CreateInstance()
        {
            return (guild_input)UIPackage.CreateObject("common_New", "guild_input");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n14 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n18 = (GImage)GetChildAt(2);
            n19 = (GImage)GetChildAt(3);
            close_btn = (CloseBtn_1)GetChildAt(4);
            txt_input = (GTextInput)GetChildAt(5);
            btn_sure = (clickBtn1)GetChildAt(6);
            n15 = (GImage)GetChildAt(7);
            n16 = (GImage)GetChildAt(8);
            title = (GTextField)GetChildAt(9);
        }
    }
}