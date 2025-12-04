/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class star_item : GComponent
    {
        public Controller status;
        public GImage n0;
        public GImage n1;
        public const string URL = "ui://argzn455cs1m1yjp81f";

        public static star_item CreateInstance()
        {
            return (star_item)UIPackage.CreateObject("fun_Dress", "star_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n0 = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
        }
    }
}