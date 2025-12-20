/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class contract_item : GComponent
    {
        public Controller state;
        public GImage n6;
        public GList reward1;
        public GList reward2;
        public GGraph get_btn1;
        public GGraph get_btn2;
        public GImage n10;
        public GImage n11;
        public GImage n13;
        public GImage lvBg;
        public GTextField lvLab;
        public const string URL = "ui://w3ox9yltin5z1yjp871";

        public static contract_item CreateInstance()
        {
            return (contract_item)UIPackage.CreateObject("fun_Recharge", "contract_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            state = GetControllerAt(0);
            n6 = (GImage)GetChildAt(0);
            reward1 = (GList)GetChildAt(1);
            reward2 = (GList)GetChildAt(2);
            get_btn1 = (GGraph)GetChildAt(3);
            get_btn2 = (GGraph)GetChildAt(4);
            n10 = (GImage)GetChildAt(5);
            n11 = (GImage)GetChildAt(6);
            n13 = (GImage)GetChildAt(7);
            lvBg = (GImage)GetChildAt(8);
            lvLab = (GTextField)GetChildAt(9);
        }
    }
}