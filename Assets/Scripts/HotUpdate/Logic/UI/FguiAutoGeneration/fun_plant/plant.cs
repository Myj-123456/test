/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_plant
{
    public partial class plant : GComponent
    {
        public Controller status;
        public GTextField placeholder;
        public GImage n24;
        public GComponent oneKey_btn;
        public GTextField tipLab;
        public GImage n31;
        public GGroup n25;
        public plant_page page;
        public search_area search_area;
        public const string URL = "ui://4905g7p7jpt92";

        public static plant CreateInstance()
        {
            return (plant)UIPackage.CreateObject("fun_plant", "plant");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            placeholder = (GTextField)GetChildAt(0);
            n24 = (GImage)GetChildAt(1);
            oneKey_btn = (GComponent)GetChildAt(2);
            tipLab = (GTextField)GetChildAt(3);
            n31 = (GImage)GetChildAt(4);
            n25 = (GGroup)GetChildAt(5);
            page = (plant_page)GetChildAt(6);
            search_area = (search_area)GetChildAt(7);
        }
    }
}