/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual
{
    public partial class handbookDemandItem : GComponent
    {
        public GImage n335;
        public GTextField title_txt;
        public GLoader Img;
        public GTextField name_txt;
        public const string URL = "ui://6q8q1ai6t77cwprw";

        public static handbookDemandItem CreateInstance()
        {
            return (handbookDemandItem)UIPackage.CreateObject("fun_CultivationManual", "handbookDemandItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n335 = (GImage)GetChildAt(0);
            title_txt = (GTextField)GetChildAt(1);
            Img = (GLoader)GetChildAt(2);
            name_txt = (GTextField)GetChildAt(3);
        }
    }
}