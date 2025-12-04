/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Plot
{
    public partial class TweenNarrationItem : GComponent
    {
        public GImage n0;
        public GTextField txt_msg;
        public const string URL = "ui://vucpfjl8vvnu6";

        public static TweenNarrationItem CreateInstance()
        {
            return (TweenNarrationItem)UIPackage.CreateObject("fun_Plot", "TweenNarrationItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            txt_msg = (GTextField)GetChildAt(1);
        }
    }
}