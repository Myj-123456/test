/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_BoonFlower
{
    public partial class videoBtn : GButton
    {
        public GImage n0;
        public GImage n1;
        public GTextField n3;
        public const string URL = "ui://fsc3a856j4qg1ayr892";

        public static videoBtn CreateInstance()
        {
            return (videoBtn)UIPackage.CreateObject("fun_BoonFlower", "videoBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
            n3 = (GTextField)GetChildAt(2);
        }
    }
}