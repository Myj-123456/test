/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Welfare
{
    public partial class turntable_item : GComponent
    {
        public GImage n0;
        public GLoader pic;
        public GTextField numLab;
        public const string URL = "ui://awswhm01s7sl1yjp846";

        public static turntable_item CreateInstance()
        {
            return (turntable_item)UIPackage.CreateObject("fun_Welfare", "turntable_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            numLab = (GTextField)GetChildAt(2);
        }
    }
}