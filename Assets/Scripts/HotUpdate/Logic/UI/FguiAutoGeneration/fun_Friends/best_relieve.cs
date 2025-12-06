/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class best_relieve : GButton
    {
        public GImage n2;
        public GTextField n5;
        public const string URL = "ui://fteyf9nzg3sj1yjp7ua";

        public static best_relieve CreateInstance()
        {
            return (best_relieve)UIPackage.CreateObject("fun_Friends", "best_relieve");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n2 = (GImage)GetChildAt(0);
            n5 = (GTextField)GetChildAt(1);
        }
    }
}