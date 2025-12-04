/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class btn_logs : GButton
    {
        public GImage n3;
        public const string URL = "ui://z1on8kwdd5kwpj8";

        public static btn_logs CreateInstance()
        {
            return (btn_logs)UIPackage.CreateObject("fun_Rob", "btn_logs");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n3 = (GImage)GetChildAt(0);
        }
    }
}