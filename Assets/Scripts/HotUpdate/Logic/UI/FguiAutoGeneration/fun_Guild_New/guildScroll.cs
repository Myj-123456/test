/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guildScroll : GComponent
    {
        public guildContent content;
        public const string URL = "ui://qz6135j3eqnf1yjp7xf";

        public static guildScroll CreateInstance()
        {
            return (guildScroll)UIPackage.CreateObject("fun_Guild_New", "guildScroll");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            content = (guildContent)GetChildAt(0);
        }
    }
}