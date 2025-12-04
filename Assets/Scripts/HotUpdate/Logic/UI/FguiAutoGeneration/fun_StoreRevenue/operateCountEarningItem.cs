/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_StoreRevenue
{
    public partial class operateCountEarningItem : GComponent
    {
        public Controller status;
        public GImage n34;
        public GImage n30;
        public GImage n31;
        public GImage n32;
        public GTextField numTxt;
        public GTextField contentTxt;
        public const string URL = "ui://6vo132lqbu8pjtwq99";

        public static operateCountEarningItem CreateInstance()
        {
            return (operateCountEarningItem)UIPackage.CreateObject("fun_StoreRevenue", "operateCountEarningItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n34 = (GImage)GetChildAt(0);
            n30 = (GImage)GetChildAt(1);
            n31 = (GImage)GetChildAt(2);
            n32 = (GImage)GetChildAt(3);
            numTxt = (GTextField)GetChildAt(4);
            contentTxt = (GTextField)GetChildAt(5);
        }
    }
}