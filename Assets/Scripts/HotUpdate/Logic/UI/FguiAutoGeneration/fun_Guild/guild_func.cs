/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guild_func : GComponent
    {
        public GImage n3;
        public GList list_func;
        public const string URL = "ui://6wv667gulmnhpdd";

        public static guild_func CreateInstance()
        {
            return (guild_func)UIPackage.CreateObject("fun_Guild", "guild_func");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n3 = (GImage)GetChildAt(0);
            list_func = (GList)GetChildAt(1);
        }
    }
}