/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class rob_list_com : GComponent
    {
        public GImage n0;
        public GList n2;
        public const string URL = "ui://z1on8kwdiy851ayr8mt";

        public static rob_list_com CreateInstance()
        {
            return (rob_list_com)UIPackage.CreateObject("fun_Rob", "rob_list_com");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            n2 = (GList)GetChildAt(1);
        }
    }
}