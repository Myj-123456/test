/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Draw
{
    public partial class detailed_list_Item : GComponent
    {
        public GImage n0;
        public GTextField title;
        public GList list;
        public const string URL = "ui://97nah3khj68sw8";

        public static detailed_list_Item CreateInstance()
        {
            return (detailed_list_Item)UIPackage.CreateObject("fun_Draw", "detailed_list_Item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            title = (GTextField)GetChildAt(1);
            list = (GList)GetChildAt(2);
        }
    }
}