/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class tour_gift_list : GComponent
    {
        public GGraph n0;
        public GList list;
        public const string URL = "ui://w3ox9yltv01m1ayr83n";

        public static tour_gift_list CreateInstance()
        {
            return (tour_gift_list)UIPackage.CreateObject("fun_Recharge", "tour_gift_list");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GGraph)GetChildAt(0);
            list = (GList)GetChildAt(1);
        }
    }
}