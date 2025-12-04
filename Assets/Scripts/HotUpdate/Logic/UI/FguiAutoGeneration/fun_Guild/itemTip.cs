/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class itemTip : GComponent
    {
        public GImage bg;
        public GList list_item;
        public const string URL = "ui://6wv667guw3yr1ayr88r";

        public static itemTip CreateInstance()
        {
            return (itemTip)UIPackage.CreateObject("fun_Guild", "itemTip");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GImage)GetChildAt(0);
            list_item = (GList)GetChildAt(1);
        }
    }
}