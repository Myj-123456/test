/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class tour_gift_cell : GComponent
    {
        public GLoader3D spine;
        public GTextField nameLab;
        public GList list;
        public buy_btn1 buy_btn;
        public const string URL = "ui://w3ox9yltv01m1ayr83o";

        public static tour_gift_cell CreateInstance()
        {
            return (tour_gift_cell)UIPackage.CreateObject("fun_Recharge", "tour_gift_cell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            spine = (GLoader3D)GetChildAt(0);
            nameLab = (GTextField)GetChildAt(1);
            list = (GList)GetChildAt(2);
            buy_btn = (buy_btn1)GetChildAt(3);
        }
    }
}