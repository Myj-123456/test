/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class pro2 : GProgressBar
    {
        public GImage n15;
        public GImage bar;
        public const string URL = "ui://w3ox9yltin5z1yjp87k";

        public static pro2 CreateInstance()
        {
            return (pro2)UIPackage.CreateObject("fun_Recharge", "pro2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n15 = (GImage)GetChildAt(0);
            bar = (GImage)GetChildAt(1);
        }
    }
}