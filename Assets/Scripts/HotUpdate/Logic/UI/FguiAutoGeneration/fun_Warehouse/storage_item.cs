/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Warehouse
{
    public partial class storage_item : GComponent
    {
        public Controller button;
        public GImage bot;
        public GImage numBg;
        public GComponent img_loader;
        public GLoader img_loaderOld;
        public GTextField count_txt;
        public const string URL = "ui://6soq1zhgsrefby";

        public static storage_item CreateInstance()
        {
            return (storage_item)UIPackage.CreateObject("fun_Warehouse", "storage_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            bot = (GImage)GetChildAt(0);
            numBg = (GImage)GetChildAt(1);
            img_loader = (GComponent)GetChildAt(2);
            img_loaderOld = (GLoader)GetChildAt(3);
            count_txt = (GTextField)GetChildAt(4);
        }
    }
}