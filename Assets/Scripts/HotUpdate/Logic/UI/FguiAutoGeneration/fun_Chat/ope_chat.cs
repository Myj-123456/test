/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Chat
{
    public partial class ope_chat : GComponent
    {
        public GGraph rect;
        public ope_com ope;
        public const string URL = "ui://z9jypfq8bwsw1yjp7wp";

        public static ope_chat CreateInstance()
        {
            return (ope_chat)UIPackage.CreateObject("fun_Chat", "ope_chat");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            rect = (GGraph)GetChildAt(0);
            ope = (ope_com)GetChildAt(1);
        }
    }
}