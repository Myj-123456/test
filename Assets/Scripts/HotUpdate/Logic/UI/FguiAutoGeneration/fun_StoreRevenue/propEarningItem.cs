/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_StoreRevenue
{
    public partial class propEarningItem : GComponent
    {
        public Controller status;
        public GLoader imgIcon;
        public GImage n24;
        public GTextField numTxt;
        public GTextField nameLab;
        public const string URL = "ui://6vo132lqrvqijtwq94";

        public static propEarningItem CreateInstance()
        {
            return (propEarningItem)UIPackage.CreateObject("fun_StoreRevenue", "propEarningItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            imgIcon = (GLoader)GetChildAt(0);
            n24 = (GImage)GetChildAt(1);
            numTxt = (GTextField)GetChildAt(2);
            nameLab = (GTextField)GetChildAt(3);
        }
    }
}