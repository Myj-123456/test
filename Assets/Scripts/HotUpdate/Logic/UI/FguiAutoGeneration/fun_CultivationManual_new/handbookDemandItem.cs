/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class handbookDemandItem : GComponent
    {
        public GImage n1;
        public GLoader Img;
        public GTextField name_txt;
        public GTextField title_txt;
        public const string URL = "ui://ekoic0wrd9bk1yjp7tf";

        public static handbookDemandItem CreateInstance()
        {
            return (handbookDemandItem)UIPackage.CreateObject("fun_CultivationManual_new", "handbookDemandItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            Img = (GLoader)GetChildAt(1);
            name_txt = (GTextField)GetChildAt(2);
            title_txt = (GTextField)GetChildAt(3);
        }
    }
}