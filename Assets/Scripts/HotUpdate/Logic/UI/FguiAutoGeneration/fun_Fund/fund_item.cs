/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Fund
{
    public partial class fund_item : GComponent
    {
        public GGraph n0;
        public GTextField limitLab;
        public GTextField proLab;
        public GButton btn;
        public GList list;
        public const string URL = "ui://9zkvgbkxbwsw1";

        public static fund_item CreateInstance()
        {
            return (fund_item)UIPackage.CreateObject("fun_Fund", "fund_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GGraph)GetChildAt(0);
            limitLab = (GTextField)GetChildAt(1);
            proLab = (GTextField)GetChildAt(2);
            btn = (GButton)GetChildAt(3);
            list = (GList)GetChildAt(4);
        }
    }
}