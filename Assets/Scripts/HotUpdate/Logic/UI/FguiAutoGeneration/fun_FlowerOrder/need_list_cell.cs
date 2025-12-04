/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerOrder
{
    public partial class need_list_cell : GComponent
    {
        public Controller enough;
        public GImage n20;
        public GLoader flower;
        public GTextField name_txt;
        public GRichTextField numLab;
        public GImage n10;
        public const string URL = "ui://6euywhvrgkun39";

        public static need_list_cell CreateInstance()
        {
            return (need_list_cell)UIPackage.CreateObject("fun_FlowerOrder", "need_list_cell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            enough = GetControllerAt(0);
            n20 = (GImage)GetChildAt(0);
            flower = (GLoader)GetChildAt(1);
            name_txt = (GTextField)GetChildAt(2);
            numLab = (GRichTextField)GetChildAt(3);
            n10 = (GImage)GetChildAt(4);
        }
    }
}