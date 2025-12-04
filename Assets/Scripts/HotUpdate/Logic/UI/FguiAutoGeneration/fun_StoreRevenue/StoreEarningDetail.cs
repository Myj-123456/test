/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_StoreRevenue
{
    public partial class StoreEarningDetail : GComponent
    {
        public GImage n67;
        public GTextField remainTimeTxt1;
        public GTextField remainTimeTxt;
        public StoreEarningGrandCont grandCont;
        public const string URL = "ui://6vo132lqeowbjtwq9a";

        public static StoreEarningDetail CreateInstance()
        {
            return (StoreEarningDetail)UIPackage.CreateObject("fun_StoreRevenue", "StoreEarningDetail");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n67 = (GImage)GetChildAt(0);
            remainTimeTxt1 = (GTextField)GetChildAt(1);
            remainTimeTxt = (GTextField)GetChildAt(2);
            grandCont = (StoreEarningGrandCont)GetChildAt(3);
        }
    }
}