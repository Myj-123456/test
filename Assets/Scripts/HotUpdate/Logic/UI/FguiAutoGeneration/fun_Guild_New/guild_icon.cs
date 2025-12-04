/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guild_icon : GComponent
    {
        public GLoader bg;
        public GLoader icon;
        public const string URL = "ui://qz6135j3s62s1yjp7z2";

        public static guild_icon CreateInstance()
        {
            return (guild_icon)UIPackage.CreateObject("fun_Guild_New", "guild_icon");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            icon = (GLoader)GetChildAt(1);
        }
    }
}