/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class first_tip1 : GComponent
    {
        public GImage n5;
        public GImage n6;
        public GTextField lab;
        public const string URL = "ui://w3ox9yltdhbs1yjp85l";

        public static first_tip1 CreateInstance()
        {
            return (first_tip1)UIPackage.CreateObject("fun_Recharge", "first_tip1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n5 = (GImage)GetChildAt(0);
            n6 = (GImage)GetChildAt(1);
            lab = (GTextField)GetChildAt(2);
        }
    }
}