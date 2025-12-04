/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guild_shop_item : GComponent
    {
        public GList list;
        public GImage n16;
        public const string URL = "ui://qz6135j3tewh1yjp7zz";

        public static guild_shop_item CreateInstance()
        {
            return (guild_shop_item)UIPackage.CreateObject("fun_Guild_New", "guild_shop_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            list = (GList)GetChildAt(0);
            n16 = (GImage)GetChildAt(1);
        }
    }
}