/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class emptyTip : GComponent
    {
        public GImage n0;
        public GImage n1;
        public GImage n2;
        public GTextField titleLab;
        public const string URL = "ui://z1on8kwdfbvs1ayr8n8";

        public static emptyTip CreateInstance()
        {
            return (emptyTip)UIPackage.CreateObject("fun_Rob", "emptyTip");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
            n2 = (GImage)GetChildAt(2);
            titleLab = (GTextField)GetChildAt(3);
        }
    }
}