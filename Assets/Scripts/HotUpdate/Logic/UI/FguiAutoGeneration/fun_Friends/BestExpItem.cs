/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class BestExpItem : GComponent
    {
        public Controller txtcontroller;
        public GImage n18;
        public GTextField Text_unLevel;
        public GTextField txt_dayExp;
        public GTextField txt_lastExp;
        public bestexp n22;
        public const string URL = "ui://fteyf9nzp3vr1yjp7vs";

        public static BestExpItem CreateInstance()
        {
            return (BestExpItem)UIPackage.CreateObject("fun_Friends", "BestExpItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            txtcontroller = GetControllerAt(0);
            n18 = (GImage)GetChildAt(0);
            Text_unLevel = (GTextField)GetChildAt(1);
            txt_dayExp = (GTextField)GetChildAt(2);
            txt_lastExp = (GTextField)GetChildAt(3);
            n22 = (bestexp)GetChildAt(4);
        }
    }
}