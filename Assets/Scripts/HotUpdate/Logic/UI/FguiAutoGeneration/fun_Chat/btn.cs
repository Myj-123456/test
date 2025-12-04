/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Chat
{
    public partial class btn : GButton
    {
        public GImage n1;
        public const string URL = "ui://z9jypfq811rnu1yjp7ww";

        public static btn CreateInstance()
        {
            return (btn)UIPackage.CreateObject("fun_Chat", "btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
        }
    }
}