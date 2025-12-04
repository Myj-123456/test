/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_ResearchPlanting
{
    public partial class FlowerStarItem : GComponent
    {
        public Controller change;
        public Controller activateStatus;
        public Controller status;
        public GButton btn_start;
        public GRichTextField lb_info;
        public GTextField lb_info_1;
        public GTextField lb_num;
        public GLoader img_icon;
        public GGroup n5;
        public const string URL = "ui://vhii0yjunqrs3";

        public static FlowerStarItem CreateInstance()
        {
            return (FlowerStarItem)UIPackage.CreateObject("fun_ResearchPlanting", "FlowerStarItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            change = GetControllerAt(0);
            activateStatus = GetControllerAt(1);
            status = GetControllerAt(2);
            btn_start = (GButton)GetChildAt(0);
            lb_info = (GRichTextField)GetChildAt(1);
            lb_info_1 = (GTextField)GetChildAt(2);
            lb_num = (GTextField)GetChildAt(3);
            img_icon = (GLoader)GetChildAt(4);
            n5 = (GGroup)GetChildAt(5);
        }
    }
}