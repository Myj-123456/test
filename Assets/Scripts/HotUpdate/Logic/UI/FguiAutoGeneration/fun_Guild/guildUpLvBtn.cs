/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guildUpLvBtn : GButton
    {
        public GImage n6;
        public GImage n8;
        public GTextField titleLab;
        public GTextField lvLab;
        public const string URL = "ui://6wv667gugtac1ayr896";

        public static guildUpLvBtn CreateInstance()
        {
            return (guildUpLvBtn)UIPackage.CreateObject("fun_Guild", "guildUpLvBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            n8 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
            lvLab = (GTextField)GetChildAt(3);
        }
    }
}