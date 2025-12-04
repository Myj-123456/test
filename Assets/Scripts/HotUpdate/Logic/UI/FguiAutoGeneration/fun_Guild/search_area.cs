/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class search_area : GComponent
    {
        public GImage n4;
        public GImage n5;
        public btn_search1 btn_search;
        public GTextInput input_name;
        public const string URL = "ui://6wv667gujpt94";

        public static search_area CreateInstance()
        {
            return (search_area)UIPackage.CreateObject("fun_Guild", "search_area");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n4 = (GImage)GetChildAt(0);
            n5 = (GImage)GetChildAt(1);
            btn_search = (btn_search1)GetChildAt(2);
            input_name = (GTextInput)GetChildAt(3);
        }
    }
}