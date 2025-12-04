/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class chatUI : GComponent
    {
        public GImage n0;
        public GImage n1;
        public GRichTextField chatLab;
        public const string URL = "ui://qz6135j3j8rp3p";

        public static chatUI CreateInstance()
        {
            return (chatUI)UIPackage.CreateObject("fun_Guild_New", "chatUI");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
            chatLab = (GRichTextField)GetChildAt(2);
        }
    }
}