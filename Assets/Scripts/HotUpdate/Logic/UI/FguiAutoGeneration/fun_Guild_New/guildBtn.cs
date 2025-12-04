/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guildBtn : GButton
    {
        public GImage n6;
        public GTextField titleLab;
        public const string URL = "ui://qz6135j3j8rp1yjp7v8";

        public static guildBtn CreateInstance()
        {
            return (guildBtn)UIPackage.CreateObject("fun_Guild_New", "guildBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
        }
    }
}