/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class btn_shield_plus : GButton
    {
        public GImage n3;
        public GImage n4;
        public GTextField n5;
        public const string URL = "ui://z1on8kwdcw741ayr8m7";

        public static btn_shield_plus CreateInstance()
        {
            return (btn_shield_plus)UIPackage.CreateObject("fun_Rob", "btn_shield_plus");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n3 = (GImage)GetChildAt(0);
            n4 = (GImage)GetChildAt(1);
            n5 = (GTextField)GetChildAt(2);
        }
    }
}