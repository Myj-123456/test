/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guild_bargain_item : GComponent
    {
        public GImage n1;
        public GLoader pic;
        public GImage n6;
        public GTextField num;
        public GTextField nameLab;
        public const string URL = "ui://qz6135j3s62s1yjp7yx";

        public static guild_bargain_item CreateInstance()
        {
            return (guild_bargain_item)UIPackage.CreateObject("fun_Guild_New", "guild_bargain_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            n6 = (GImage)GetChildAt(2);
            num = (GTextField)GetChildAt(3);
            nameLab = (GTextField)GetChildAt(4);
        }
    }
}