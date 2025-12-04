/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerOrder
{
    public partial class txt_pro : GComponent
    {
        public GImage n83;
        public GRichTextField numLab;
        public const string URL = "ui://6euywhvrsfylnzs";

        public static txt_pro CreateInstance()
        {
            return (txt_pro)UIPackage.CreateObject("fun_FlowerOrder", "txt_pro");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n83 = (GImage)GetChildAt(0);
            numLab = (GRichTextField)GetChildAt(1);
        }
    }
}