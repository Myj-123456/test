/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_ResearchPlanting
{
    public partial class FlowerSelectView : GComponent
    {
        public GButton close_btn;
        public GList list;
        public GTextField lb_pageCount;
        public GButton btn_turn_left;
        public GButton btn_turn_right;
        public GRichTextField lb_tip;
        public const string URL = "ui://vhii0yjunqrs5";

        public static FlowerSelectView CreateInstance()
        {
            return (FlowerSelectView)UIPackage.CreateObject("fun_ResearchPlanting", "FlowerSelectView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            close_btn = (GButton)GetChildAt(0);
            list = (GList)GetChildAt(1);
            lb_pageCount = (GTextField)GetChildAt(2);
            btn_turn_left = (GButton)GetChildAt(3);
            btn_turn_right = (GButton)GetChildAt(4);
            lb_tip = (GRichTextField)GetChildAt(5);
        }
    }
}