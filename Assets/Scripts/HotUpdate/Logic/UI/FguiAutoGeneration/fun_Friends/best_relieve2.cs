/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class best_relieve2 : GButton
    {
        public GImage n2;
        public GTextField txt_relieveTime;
        public GTextField n5;
        public const string URL = "ui://fteyf9nzl0u91yjp7uj";

        public static best_relieve2 CreateInstance()
        {
            return (best_relieve2)UIPackage.CreateObject("fun_Friends", "best_relieve2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n2 = (GImage)GetChildAt(0);
            txt_relieveTime = (GTextField)GetChildAt(1);
            n5 = (GTextField)GetChildAt(2);
        }
    }
}