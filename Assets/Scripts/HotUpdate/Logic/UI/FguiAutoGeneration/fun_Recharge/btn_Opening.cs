/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class btn_Opening : GButton
    {
        public GTextField n3;
        public const string URL = "ui://w3ox9yltj68s1yjp891";

        public static btn_Opening CreateInstance()
        {
            return (btn_Opening)UIPackage.CreateObject("fun_Recharge", "btn_Opening");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n3 = (GTextField)GetChildAt(0);
        }
    }
}