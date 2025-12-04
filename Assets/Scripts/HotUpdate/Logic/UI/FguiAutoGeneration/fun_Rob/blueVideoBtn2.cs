/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class blueVideoBtn2 : GButton
    {
        public GImage n6;
        public GTextField titleLab;
        public GImage n10;
        public const string URL = "ui://z1on8kwdbqlm1ayr8ky";

        public static blueVideoBtn2 CreateInstance()
        {
            return (blueVideoBtn2)UIPackage.CreateObject("fun_Rob", "blueVideoBtn2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
            n10 = (GImage)GetChildAt(2);
        }
    }
}