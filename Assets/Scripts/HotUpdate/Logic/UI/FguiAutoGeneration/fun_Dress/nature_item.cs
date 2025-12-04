/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class nature_item : GComponent
    {
        public Controller unlock;
        public GImage n4;
        public GImage n2;
        public GImage n6;
        public GTextField natureLab;
        public const string URL = "ui://argzn455m3gh1l";

        public static nature_item CreateInstance()
        {
            return (nature_item)UIPackage.CreateObject("fun_Dress", "nature_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            unlock = GetControllerAt(0);
            n4 = (GImage)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            n6 = (GImage)GetChildAt(2);
            natureLab = (GTextField)GetChildAt(3);
        }
    }
}