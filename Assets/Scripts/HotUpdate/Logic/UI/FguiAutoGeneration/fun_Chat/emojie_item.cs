/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Chat
{
    public partial class emojie_item : GComponent
    {
        public GLoader pic;
        public const string URL = "ui://z9jypfq8sh8h1yjp7xb";

        public static emojie_item CreateInstance()
        {
            return (emojie_item)UIPackage.CreateObject("fun_Chat", "emojie_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            pic = (GLoader)GetChildAt(0);
        }
    }
}