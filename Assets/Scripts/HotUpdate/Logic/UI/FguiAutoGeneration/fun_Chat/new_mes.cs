/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Chat
{
    public partial class new_mes : GComponent
    {
        public GImage n5;
        public GTextField nsgNum;
        public const string URL = "ui://z9jypfq8bwsw1yjp7wo";

        public static new_mes CreateInstance()
        {
            return (new_mes)UIPackage.CreateObject("fun_Chat", "new_mes");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n5 = (GImage)GetChildAt(0);
            nsgNum = (GTextField)GetChildAt(1);
        }
    }
}