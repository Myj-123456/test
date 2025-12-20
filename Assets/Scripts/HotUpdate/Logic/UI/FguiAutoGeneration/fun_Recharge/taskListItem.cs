/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class taskListItem : GComponent
    {
        public GImage n0;
        public GImage n1;
        public GImage n3;
        public GTextField titleLab;
        public GList list;
        public const string URL = "ui://w3ox9yltin5z1yjp87p";

        public static taskListItem CreateInstance()
        {
            return (taskListItem)UIPackage.CreateObject("fun_Recharge", "taskListItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
            n3 = (GImage)GetChildAt(2);
            titleLab = (GTextField)GetChildAt(3);
            list = (GList)GetChildAt(4);
        }
    }
}