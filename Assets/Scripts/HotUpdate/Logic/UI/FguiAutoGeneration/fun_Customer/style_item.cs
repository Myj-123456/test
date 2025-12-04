/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Customer
{
    public partial class style_item : GComponent
    {
        public Controller status;
        public GLoader pic;
        public const string URL = "ui://pcr735xhcs1m8";

        public static style_item CreateInstance()
        {
            return (style_item)UIPackage.CreateObject("fun_Customer", "style_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            pic = (GLoader)GetChildAt(0);
        }
    }
}