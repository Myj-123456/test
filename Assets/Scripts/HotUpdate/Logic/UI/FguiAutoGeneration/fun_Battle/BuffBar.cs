/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Battle
{
    public partial class BuffBar : GComponent
    {
        public GList list_buff;
        public const string URL = "ui://z1b78orpphdam";

        public static BuffBar CreateInstance()
        {
            return (BuffBar)UIPackage.CreateObject("fun_Battle", "BuffBar");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            list_buff = (GList)GetChildAt(0);
        }
    }
}