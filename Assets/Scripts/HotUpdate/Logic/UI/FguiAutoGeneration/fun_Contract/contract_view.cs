/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Contract
{
    public partial class contract_view : GComponent
    {
        public GGraph n0;
        public GList list;
        public GList task_list;
        public GTextField lvLab;
        public pro pro;
        public GTextField proLab;
        public GButton buy_lv_btn;
        public GButton day_btn;
        public GButton challenge_btn;
        public GButton buy1_btn;
        public GButton buy2_btn;
        public GButton close_btn;
        public const string URL = "ui://ju8ssus8kkb11ayr82p";

        public static contract_view CreateInstance()
        {
            return (contract_view)UIPackage.CreateObject("fun_Contract", "contract_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GGraph)GetChildAt(0);
            list = (GList)GetChildAt(1);
            task_list = (GList)GetChildAt(2);
            lvLab = (GTextField)GetChildAt(3);
            pro = (pro)GetChildAt(4);
            proLab = (GTextField)GetChildAt(5);
            buy_lv_btn = (GButton)GetChildAt(6);
            day_btn = (GButton)GetChildAt(7);
            challenge_btn = (GButton)GetChildAt(8);
            buy1_btn = (GButton)GetChildAt(9);
            buy2_btn = (GButton)GetChildAt(10);
            close_btn = (GButton)GetChildAt(11);
        }
    }
}