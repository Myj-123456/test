/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guildBtn1 : GButton
    {
        public GImage n6;
        public GTextField titleLab;
        public const string URL = "ui://qz6135j3l2dk1yjp7xu";

        public static guildBtn1 CreateInstance()
        {
            return (guildBtn1)UIPackage.CreateObject("fun_Guild_New", "guildBtn1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
        }
    }
}