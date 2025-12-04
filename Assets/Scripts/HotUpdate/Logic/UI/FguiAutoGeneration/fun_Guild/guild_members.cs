/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guild_members : GComponent
    {
        public GList list_players;
        public const string URL = "ui://6wv667gulmnhpdc";

        public static guild_members CreateInstance()
        {
            return (guild_members)UIPackage.CreateObject("fun_Guild", "guild_members");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            list_players = (GList)GetChildAt(0);
        }
    }
}