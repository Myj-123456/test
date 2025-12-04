/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Chat
{
    public partial class chatHead : GComponent
    {
        public GLoader img_head;
        public GComponent picFrame;
        public const string URL = "ui://z9jypfq8m9g1ph7";

        public static chatHead CreateInstance()
        {
            return (chatHead)UIPackage.CreateObject("fun_Chat", "chatHead");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            img_head = (GLoader)GetChildAt(0);
            picFrame = (GComponent)GetChildAt(1);
        }
    }
}