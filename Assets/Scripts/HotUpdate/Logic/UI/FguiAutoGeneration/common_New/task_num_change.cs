/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class task_num_change : GComponent
    {
        public Controller status;
        public GImage n9;
        public GTextField decLab;
        public GTextField tip;
        public const string URL = "ui://mjiw43v9bwsw1yjp83a";

        public static task_num_change CreateInstance()
        {
            return (task_num_change)UIPackage.CreateObject("common_New", "task_num_change");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n9 = (GImage)GetChildAt(0);
            decLab = (GTextField)GetChildAt(1);
            tip = (GTextField)GetChildAt(2);
        }
    }
}