/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_StoreRevenue
{
    public partial class opeContainer : GComponent
    {
        public operateCountEarningItem n0;
        public operateCountEarningItem n1;
        public operateCountEarningItem n2;
        public GImage n4;
        public GImage n5;
        public GImage n6;
        public GTextField opeTitle;
        public const string URL = "ui://6vo132lqvag2jtwq9d";

        public static opeContainer CreateInstance()
        {
            return (opeContainer)UIPackage.CreateObject("fun_StoreRevenue", "opeContainer");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (operateCountEarningItem)GetChildAt(0);
            n1 = (operateCountEarningItem)GetChildAt(1);
            n2 = (operateCountEarningItem)GetChildAt(2);
            n4 = (GImage)GetChildAt(3);
            n5 = (GImage)GetChildAt(4);
            n6 = (GImage)GetChildAt(5);
            opeTitle = (GTextField)GetChildAt(6);
        }
    }
}