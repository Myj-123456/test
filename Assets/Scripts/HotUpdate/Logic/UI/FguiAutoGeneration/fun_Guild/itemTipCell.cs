/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class itemTipCell : GComponent
    {
        public GLoader loader_icon;
        public GRichTextField txt_name;
        public const string URL = "ui://6wv667guw3yr1ayr88s";

        public static itemTipCell CreateInstance()
        {
            return (itemTipCell)UIPackage.CreateObject("fun_Guild", "itemTipCell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            loader_icon = (GLoader)GetChildAt(0);
            txt_name = (GRichTextField)GetChildAt(1);
        }
    }
}