/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_ResearchPlanting
{
    public partial class FkowerSelectItem : GComponent
    {
        public GImage n11;
        public GLoader img_flower;
        public GImage n12;
        public GTextField lb_level;
        public GList ls_star;
        public const string URL = "ui://vhii0yjunqrs1ayr7wq";

        public static FkowerSelectItem CreateInstance()
        {
            return (FkowerSelectItem)UIPackage.CreateObject("fun_ResearchPlanting", "FkowerSelectItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n11 = (GImage)GetChildAt(0);
            img_flower = (GLoader)GetChildAt(1);
            n12 = (GImage)GetChildAt(2);
            lb_level = (GTextField)GetChildAt(3);
            ls_star = (GList)GetChildAt(4);
        }
    }
}