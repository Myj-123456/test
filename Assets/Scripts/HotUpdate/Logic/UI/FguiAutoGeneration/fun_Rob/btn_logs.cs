/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class btn_logs : GButton
    {
        public GImage n4;
        public GImage n5;
        public GImage n6;
        public GTextField titleLab;
        public GLoader pic;
        public const string URL = "ui://z1on8kwdd5kwpj8";

        public static btn_logs CreateInstance()
        {
            return (btn_logs)UIPackage.CreateObject("fun_Rob", "btn_logs");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n4 = (GImage)GetChildAt(0);
            n5 = (GImage)GetChildAt(1);
            n6 = (GImage)GetChildAt(2);
            titleLab = (GTextField)GetChildAt(3);
            pic = (GLoader)GetChildAt(4);
        }
    }
}