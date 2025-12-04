/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Decrypt
{
    public partial class decrypt_bridge_view : GComponent
    {
        public GLoader bg;
        public decrypt_bridge_item board;
        public const string URL = "ui://vlp4zk70xc4q2";

        public static decrypt_bridge_view CreateInstance()
        {
            return (decrypt_bridge_view)UIPackage.CreateObject("fun_Decrypt", "decrypt_bridge_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            board = (decrypt_bridge_item)GetChildAt(1);
        }
    }
}