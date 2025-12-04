/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Welfare
{
    public partial class growth_item : GComponent
    {
        public Controller status;
        public GImage n1;
        public GImage n2;
        public GImage n4;
        public GTextField titleLab;
        public GRichTextField proLab;
        public GList list;
        public btn goto_btn;
        public btn get_btn;
        public const string URL = "ui://awswhm01g0s01s";

        public static growth_item CreateInstance()
        {
            return (growth_item)UIPackage.CreateObject("fun_Welfare", "growth_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            n4 = (GImage)GetChildAt(2);
            titleLab = (GTextField)GetChildAt(3);
            proLab = (GRichTextField)GetChildAt(4);
            list = (GList)GetChildAt(5);
            goto_btn = (btn)GetChildAt(6);
            get_btn = (btn)GetChildAt(7);
        }
    }
}