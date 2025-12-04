/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Customer
{
    public partial class chose_qualirt : GComponent
    {
        public GImage n1;
        public GList chose_list;
        public const string URL = "ui://pcr735xhcs1m1yjp7wp";

        public static chose_qualirt CreateInstance()
        {
            return (chose_qualirt)UIPackage.CreateObject("fun_Customer", "chose_qualirt");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            chose_list = (GList)GetChildAt(1);
        }
    }
}