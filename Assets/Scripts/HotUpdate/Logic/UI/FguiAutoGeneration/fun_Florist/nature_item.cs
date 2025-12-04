/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Florist
{
    public partial class nature_item : GComponent
    {
        public Controller status;
        public GImage n4;
        public GTextField lab;
        public const string URL = "ui://nj16dzxym3ghe";

        public static nature_item CreateInstance()
        {
            return (nature_item)UIPackage.CreateObject("fun_Florist", "nature_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n4 = (GImage)GetChildAt(0);
            lab = (GTextField)GetChildAt(1);
        }
    }
}