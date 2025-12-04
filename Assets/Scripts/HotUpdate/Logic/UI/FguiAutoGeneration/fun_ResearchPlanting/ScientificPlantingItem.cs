/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_ResearchPlanting
{
    public partial class ScientificPlantingItem : GComponent
    {
        public Controller status;
        public GLoader img_item;
        public GButton btn_item_add;
        public GButton btn_item_odd;
        public const string URL = "ui://vhii0yjunqrs1";

        public static ScientificPlantingItem CreateInstance()
        {
            return (ScientificPlantingItem)UIPackage.CreateObject("fun_ResearchPlanting", "ScientificPlantingItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            img_item = (GLoader)GetChildAt(0);
            btn_item_add = (GButton)GetChildAt(1);
            btn_item_odd = (GButton)GetChildAt(2);
        }
    }
}