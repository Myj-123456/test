/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class handbook_filter : GComponent
    {
        public Controller status;
        public GImage n34;
        public GImage n31;
        public GImage n32;
        public GImage n33;
        public filter_item filter_had;
        public filter_item filter_unhaved;
        public filter_item filter_type_6;
        public filter_item filter_type_5;
        public filter_item filter_type_4;
        public filter_item filter_type_1;
        public filter_item filter_type_2;
        public filter_item filter_type_3;
        public btn btn_search;
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
            n34 = (GImage)GetChildAt(0);
            n31 = (GImage)GetChildAt(1);
            n32 = (GImage)GetChildAt(2);
            n33 = (GImage)GetChildAt(3);
            filter_had = (filter_item)GetChildAt(4);
            filter_unhaved = (filter_item)GetChildAt(5);
            filter_type_6 = (filter_item)GetChildAt(6);
            filter_type_5 = (filter_item)GetChildAt(7);
            filter_type_4 = (filter_item)GetChildAt(8);
            filter_type_1 = (filter_item)GetChildAt(9);
            filter_type_2 = (filter_item)GetChildAt(10);
            filter_type_3 = (filter_item)GetChildAt(11);
            btn_search = (btn)GetChildAt(12);
            search_input_text = (GTextInput)GetChildAt(13);
            filter_style_6 = (filter_item)GetChildAt(14);
            filter_style_5 = (filter_item)GetChildAt(15);
            filter_style_4 = (filter_item)GetChildAt(16);
            filter_style_1 = (filter_item)GetChildAt(17);
            filter_style_2 = (filter_item)GetChildAt(18);
            filter_style_3 = (filter_item)GetChildAt(19);
            n29 = (GGroup)GetChildAt(20);
        }
    }
}