/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class writeBtn : GButton
    {
        public GImage n4;
        public const string URL = "ui://6wv667gutosm1ayr88w";

        public static writeBtn CreateInstance()
        {
            return (writeBtn)UIPackage.CreateObject("fun_Guild", "writeBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n4 = (GImage)GetChildAt(0);
        }
    }
}