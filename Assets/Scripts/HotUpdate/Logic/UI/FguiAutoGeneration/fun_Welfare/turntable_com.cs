/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Welfare
{
    public partial class turntable_com : GComponent
    {
        public turntable_item item1;
        public turntable_item item2;
        public turntable_item item3;
        public turntable_item item4;
        public turntable_item item5;
        public const string URL = "ui://awswhm01s7sl1yjp847";

        public static turntable_com CreateInstance()
        {
            return (turntable_com)UIPackage.CreateObject("fun_Welfare", "turntable_com");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            item1 = (turntable_item)GetChildAt(0);
            item2 = (turntable_item)GetChildAt(1);
            item3 = (turntable_item)GetChildAt(2);
            item4 = (turntable_item)GetChildAt(3);
            item5 = (turntable_item)GetChildAt(4);
        }
    }
}