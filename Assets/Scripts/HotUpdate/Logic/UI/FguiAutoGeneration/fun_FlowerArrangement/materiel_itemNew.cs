/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerArrangement
{
    public partial class materiel_itemNew : GComponent
    {
        public GImage bg;
        public GLoader img_loader;
        public GTextField num;
        public const string URL = "ui://6kofjj39qarjp36";

        public static materiel_itemNew CreateInstance()
        {
            return (materiel_itemNew)UIPackage.CreateObject("fun_FlowerArrangement", "materiel_itemNew");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GImage)GetChildAt(0);
            img_loader = (GLoader)GetChildAt(1);
            num = (GTextField)GetChildAt(2);
        }
    }
}