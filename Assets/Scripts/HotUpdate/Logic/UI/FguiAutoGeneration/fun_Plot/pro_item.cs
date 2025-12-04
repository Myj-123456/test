/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Plot
{
    public partial class pro_item : GComponent
    {
        public Controller type;
        public GImage n0;
        public GImage n1;
        public GImage n2;
        public const string URL = "ui://vucpfjl8accs1yjp838";

        public static pro_item CreateInstance()
        {
            return (pro_item)UIPackage.CreateObject("fun_Plot", "pro_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            n0 = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
            n2 = (GImage)GetChildAt(2);
        }
    }
}