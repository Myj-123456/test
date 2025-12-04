/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual
{
    public partial class handbook_filter : GComponent
    {
        public GImage n1;
        public GImage n26;
        public GImage n27;
        public GImage n12;
        public filter_item filter_had;
        public filter_item filter_unhaved;
        public filter_item filter_type_6;
        public filter_item filter_type_5;
        public filter_item filter_type_4;
        public filter_item filter_type_1;
        public filter_item filter_type_2;
        public filter_item filter_type_3;
        public GButton btn_search;
        public GTextInput search_input_text;
        public const string URL = "ui://6q8q1ai6hhsw1ayr846";

        public static handbook_filter CreateInstance()
        {
            return (handbook_filter)UIPackage.CreateObject("fun_CultivationManual", "handbook_filter");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            n26 = (GImage)GetChildAt(1);
            n27 = (GImage)GetChildAt(2);
            n12 = (GImage)GetChildAt(3);
            filter_had = (filter_item)GetChildAt(4);
            filter_unhaved = (filter_item)GetChildAt(5);
            filter_type_6 = (filter_item)GetChildAt(6);
            filter_type_5 = (filter_item)GetChildAt(7);
            filter_type_4 = (filter_item)GetChildAt(8);
            filter_type_1 = (filter_item)GetChildAt(9);
            filter_type_2 = (filter_item)GetChildAt(10);
            filter_type_3 = (filter_item)GetChildAt(11);
            btn_search = (GButton)GetChildAt(12);
            search_input_text = (GTextInput)GetChildAt(13);
        }
    }
}