/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class handbook_filter : GComponent
    {
        public Controller status;
        public GImage n22;
        public filter_item filter_had;
        public filter_item filter_unhaved;
        public filter_item filter_type_6;
        public filter_item filter_type_5;
        public filter_item filter_type_4;
        public filter_item filter_type_1;
        public filter_item filter_type_2;
        public filter_item filter_type_3;
        public blueBgBtn btn_search;
        public GTextInput search_input_text;
        public filter_item filter_style_6;
        public filter_item filter_style_5;
        public filter_item filter_style_4;
        public filter_item filter_style_1;
        public filter_item filter_style_2;
        public filter_item filter_style_3;
        public GGroup n29;
        public const string URL = "ui://ekoic0wriustx";

        public static handbook_filter CreateInstance()
        {
            return (handbook_filter)UIPackage.CreateObject("fun_CultivationManual_new", "handbook_filter");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n22 = (GImage)GetChildAt(0);
            filter_had = (filter_item)GetChildAt(1);
            filter_unhaved = (filter_item)GetChildAt(2);
            filter_type_6 = (filter_item)GetChildAt(3);
            filter_type_5 = (filter_item)GetChildAt(4);
            filter_type_4 = (filter_item)GetChildAt(5);
            filter_type_1 = (filter_item)GetChildAt(6);
            filter_type_2 = (filter_item)GetChildAt(7);
            filter_type_3 = (filter_item)GetChildAt(8);
            btn_search = (blueBgBtn)GetChildAt(9);
            search_input_text = (GTextInput)GetChildAt(10);
            filter_style_6 = (filter_item)GetChildAt(11);
            filter_style_5 = (filter_item)GetChildAt(12);
            filter_style_4 = (filter_item)GetChildAt(13);
            filter_style_1 = (filter_item)GetChildAt(14);
            filter_style_2 = (filter_item)GetChildAt(15);
            filter_style_3 = (filter_item)GetChildAt(16);
            n29 = (GGroup)GetChildAt(17);
        }
    }
}