/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class catchBtn : GButton
    {
        public GImage n11;
        public const string URL = "ui://z1on8kwdcw741ayr8m6";

        public static catchBtn CreateInstance()
        {
            return (catchBtn)UIPackage.CreateObject("fun_Rob", "catchBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n11 = (GImage)GetChildAt(0);
        }
    }
}