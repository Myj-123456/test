/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Contract
{
    public partial class contract_item : GComponent
    {
        public GGraph n500;
        public GList reward1;
        public GList reward2;
        public GTextField lvLab;
        public GGraph get_btn1;
        public GGraph get_btn2;
        public const string URL = "ui://ju8ssus8kkb11ayr82q";

        public static contract_item CreateInstance()
        {
            return (contract_item)UIPackage.CreateObject("fun_Contract", "contract_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n500 = (GGraph)GetChildAt(0);
            reward1 = (GList)GetChildAt(1);
            reward2 = (GList)GetChildAt(2);
            lvLab = (GTextField)GetChildAt(3);
            get_btn1 = (GGraph)GetChildAt(4);
            get_btn2 = (GGraph)GetChildAt(5);
        }
    }
}