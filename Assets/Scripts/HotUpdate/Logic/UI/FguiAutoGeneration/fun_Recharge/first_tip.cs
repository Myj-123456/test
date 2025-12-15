/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class first_tip : GComponent
    {
        public GImage n0;
        public GImage n2;
        public GImage n3;
        public GImage n4;
        public GImage n6;
        public const string URL = "ui://w3ox9yltdhbs1yjp85k";

        public static first_tip CreateInstance()
        {
            return (first_tip)UIPackage.CreateObject("fun_Recharge", "first_tip");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            n3 = (GImage)GetChildAt(2);
            n4 = (GImage)GetChildAt(3);
            n6 = (GImage)GetChildAt(4);
        }
    }
}