/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guild_not_bargain_item : GComponent
    {
        public Controller type;
        public GImage n4;
        public GTextField nameLab;
        public GTextField timeLab;
        public const string URL = "ui://qz6135j3s62s1yjp7z5";

        public static guild_not_bargain_item CreateInstance()
        {
            return (guild_not_bargain_item)UIPackage.CreateObject("fun_Guild_New", "guild_not_bargain_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            n4 = (GImage)GetChildAt(0);
            nameLab = (GTextField)GetChildAt(1);
            timeLab = (GTextField)GetChildAt(2);
        }
    }
}