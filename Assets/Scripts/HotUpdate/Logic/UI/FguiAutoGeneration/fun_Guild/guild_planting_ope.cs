/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guild_planting_ope : GComponent
    {
        public plant plantUI;
        public GButton closeBtn;
        public const string URL = "ui://6wv667gu6pbpphf";

        public static guild_planting_ope CreateInstance()
        {
            return (guild_planting_ope)UIPackage.CreateObject("fun_Guild", "guild_planting_ope");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            plantUI = (plant)GetChildAt(0);
            closeBtn = (GButton)GetChildAt(1);
        }
    }
}