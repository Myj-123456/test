/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class bestNullTip : GComponent
    {
        public GImage n0;
        public GTextField n1;
        public const string URL = "ui://fteyf9nzg3sj1yjp7uc";

        public static bestNullTip CreateInstance()
        {
            return (bestNullTip)UIPackage.CreateObject("fun_Friends", "bestNullTip");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            n1 = (GTextField)GetChildAt(1);
        }
    }
}