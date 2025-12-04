/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_plant
{
    public partial class pageNum : GComponent
    {
        public GImage n2;
        public GRichTextField lb_number;
        public const string URL = "ui://4905g7p7owcx13";

        public static pageNum CreateInstance()
        {
            return (pageNum)UIPackage.CreateObject("fun_plant", "pageNum");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n2 = (GImage)GetChildAt(0);
            lb_number = (GRichTextField)GetChildAt(1);
        }
    }
}