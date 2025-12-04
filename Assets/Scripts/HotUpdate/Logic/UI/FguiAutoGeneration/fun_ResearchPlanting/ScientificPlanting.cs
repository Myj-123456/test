/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_ResearchPlanting
{
    public partial class ScientificPlanting : GComponent
    {
        public Controller status;
        public GButton close_btn;
        public GRichTextField lb_reflushTime;
        public GLoader img_item;
        public probar valueBar;
        public GTextField lb_itemName;
        public GTextField lb_hasCount;
        public GTextField lb_cultivationCount;
        public GTextField lb_progress;
        public GButton btn_submit;
        public GList ls_item;
        public GButton btn_clearTime;
        public const string URL = "ui://vhii0yjunqrs0";

        public static ScientificPlanting CreateInstance()
        {
            return (ScientificPlanting)UIPackage.CreateObject("fun_ResearchPlanting", "ScientificPlanting");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            close_btn = (GButton)GetChildAt(0);
            lb_reflushTime = (GRichTextField)GetChildAt(1);
            img_item = (GLoader)GetChildAt(2);
            valueBar = (probar)GetChildAt(3);
            lb_itemName = (GTextField)GetChildAt(4);
            lb_hasCount = (GTextField)GetChildAt(5);
            lb_cultivationCount = (GTextField)GetChildAt(6);
            lb_progress = (GTextField)GetChildAt(7);
            btn_submit = (GButton)GetChildAt(8);
            ls_item = (GList)GetChildAt(9);
            btn_clearTime = (GButton)GetChildAt(10);
        }
    }
}