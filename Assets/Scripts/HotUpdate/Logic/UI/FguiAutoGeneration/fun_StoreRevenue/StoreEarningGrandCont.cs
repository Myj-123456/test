/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_StoreRevenue
{
    public partial class StoreEarningGrandCont : GComponent
    {
        public ticketContainer ticketCont;
        public opeContainer opeCont;
        public const string URL = "ui://6vo132lqvag2jtwq9f";

        public static StoreEarningGrandCont CreateInstance()
        {
            return (StoreEarningGrandCont)UIPackage.CreateObject("fun_StoreRevenue", "StoreEarningGrandCont");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            ticketCont = (ticketContainer)GetChildAt(0);
            opeCont = (opeContainer)GetChildAt(1);
        }
    }
}