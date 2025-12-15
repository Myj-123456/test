/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class pro : GProgressBar
    {
        public GImage n15;
        public GImage n16;
        public const string URL = "ui://w3ox9yltdidl1ayr820";

        public static pro CreateInstance()
        {
            return (pro)UIPackage.CreateObject("fun_Recharge", "pro");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n15 = (GImage)GetChildAt(0);
            n16 = (GImage)GetChildAt(1);
        }
    }
}