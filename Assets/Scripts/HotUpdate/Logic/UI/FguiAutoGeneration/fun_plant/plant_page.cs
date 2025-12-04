/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_plant
{
    public partial class plant_page : GComponent
    {
        public btn_turn btn_PageRight;
        public pageNum page;
        public btn_turn btn_PageLeft;
        public btn_flower_sort btn_sort;
        public const string URL = "ui://4905g7p7owcx14";

        public static plant_page CreateInstance()
        {
            return (plant_page)UIPackage.CreateObject("fun_plant", "plant_page");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            btn_PageRight = (btn_turn)GetChildAt(0);
            page = (pageNum)GetChildAt(1);
            btn_PageLeft = (btn_turn)GetChildAt(2);
            btn_sort = (btn_flower_sort)GetChildAt(3);
        }
    }
}