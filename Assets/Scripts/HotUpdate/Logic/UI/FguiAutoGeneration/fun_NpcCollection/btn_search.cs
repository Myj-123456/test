/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_NpcCollection
{
    public partial class btn_search : GButton
    {
        public GImage n3;
        public GTextField n4;
        public const string URL = "ui://ydpeia1vplz71h";

        public static btn_search CreateInstance()
        {
            return (btn_search)UIPackage.CreateObject("fun_NpcCollection", "btn_search");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n3 = (GImage)GetChildAt(0);
            n4 = (GTextField)GetChildAt(1);
        }
    }
}