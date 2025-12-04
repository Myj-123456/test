/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class shareItem : GComponent
    {
        public GLoader img;
        public GImage n11;
        public GTextField numLab;
        public const string URL = "ui://ekoic0wrq47x1yjp7w2";

        public static shareItem CreateInstance()
        {
            return (shareItem)UIPackage.CreateObject("fun_CultivationManual_new", "shareItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            img = (GLoader)GetChildAt(0);
            n11 = (GImage)GetChildAt(1);
            numLab = (GTextField)GetChildAt(2);
        }
    }
}