/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guild_func_btn : GComponent
    {
        public GImage n13;
        public GLoader icon_loader;
        public GImage red_point;
        public GTextField txt_name;
        public const string URL = "ui://6wv667guifmjpeu";

        public static guild_func_btn CreateInstance()
        {
            return (guild_func_btn)UIPackage.CreateObject("fun_Guild", "guild_func_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n13 = (GImage)GetChildAt(0);
            icon_loader = (GLoader)GetChildAt(1);
            red_point = (GImage)GetChildAt(2);
            txt_name = (GTextField)GetChildAt(3);
        }
    }
}