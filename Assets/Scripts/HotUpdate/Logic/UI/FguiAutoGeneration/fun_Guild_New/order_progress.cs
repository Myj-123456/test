/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class order_progress : GProgressBar
    {
        public GImage n5;
        public GImage bar;
        public const string URL = "ui://qz6135j3tewh1ayr89b";

        public static order_progress CreateInstance()
        {
            return (order_progress)UIPackage.CreateObject("fun_Guild_New", "order_progress");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n5 = (GImage)GetChildAt(0);
            bar = (GImage)GetChildAt(1);
        }
    }
}