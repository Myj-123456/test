/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Plot
{
    public partial class NarrationItem : GComponent
    {
        public TweenNarrationItem item;
        public const string URL = "ui://vucpfjl8rqny1";

        public static NarrationItem CreateInstance()
        {
            return (NarrationItem)UIPackage.CreateObject("fun_Plot", "NarrationItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            item = (TweenNarrationItem)GetChildAt(0);
        }
    }
}