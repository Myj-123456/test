/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class btn : GButton
    {
        public GImage n0;
        public const string URL = "ui://w3ox9yltg0s01ayr82e";

        public static btn CreateInstance()
        {
            return (btn)UIPackage.CreateObject("fun_Recharge", "btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
        }
    }
}