/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class common_add : GButton
    {
        public GImage n2;
        public const string URL = "ui://z1on8kwdfbvs1ayr8n4";

        public static common_add CreateInstance()
        {
            return (common_add)UIPackage.CreateObject("fun_Rob", "common_add");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n2 = (GImage)GetChildAt(0);
        }
    }
}