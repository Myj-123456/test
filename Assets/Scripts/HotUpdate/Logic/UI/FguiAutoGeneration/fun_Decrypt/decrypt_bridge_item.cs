/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Decrypt
{
    public partial class decrypt_bridge_item : GComponent
    {
        public GGraph n0;
        public const string URL = "ui://vlp4zk70xc4q3";

        public static decrypt_bridge_item CreateInstance()
        {
            return (decrypt_bridge_item)UIPackage.CreateObject("fun_Decrypt", "decrypt_bridge_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GGraph)GetChildAt(0);
        }
    }
}