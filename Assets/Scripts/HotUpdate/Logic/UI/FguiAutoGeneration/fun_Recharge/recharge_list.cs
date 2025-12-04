/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class recharge_list : GComponent
    {
        public GList buy_list;
        public GGraph rect;
        public const string URL = "ui://w3ox9yltdidl20";

        public static recharge_list CreateInstance()
        {
            return (recharge_list)UIPackage.CreateObject("fun_Recharge", "recharge_list");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            buy_list = (GList)GetChildAt(0);
            rect = (GGraph)GetChildAt(1);
        }
    }
}