/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class look_btn : GButton
    {
        public GImage n3;
        public const string URL = "ui://w3ox9yltdidl1q";

        public static look_btn CreateInstance()
        {
            return (look_btn)UIPackage.CreateObject("fun_Recharge", "look_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n3 = (GImage)GetChildAt(0);
        }
    }
}