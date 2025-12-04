/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Chat
{
    public partial class emojie_view : GComponent
    {
        public GImage n1;
        public GList emojie_list;
        public const string URL = "ui://z9jypfq8sh8h1yjp7x7";

        public static emojie_view CreateInstance()
        {
            return (emojie_view)UIPackage.CreateObject("fun_Chat", "emojie_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            emojie_list = (GList)GetChildAt(1);
        }
    }
}