/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual
{
    public partial class filter_item : GComponent
    {
        public Controller status;
        public GImage n5;
        public GImage img_selected;
        public GTextField titleLab;
        public const string URL = "ui://6q8q1ai6hhsw1ayr84c";

        public static filter_item CreateInstance()
        {
            return (filter_item)UIPackage.CreateObject("fun_CultivationManual", "filter_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n5 = (GImage)GetChildAt(0);
            img_selected = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}