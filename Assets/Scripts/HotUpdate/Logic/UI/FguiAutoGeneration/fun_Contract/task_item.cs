/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Contract
{
    public partial class task_item : GComponent
    {
        public Controller status;
        public GGraph n94;
        public GList list;
        public GButton goto_btn;
        public GButton get_btn;
        public pro pro;
        public GTextField proLab;
        public GTextField titleLab;
        public const string URL = "ui://ju8ssus8kkb11yjp845";

        public static task_item CreateInstance()
        {
            return (task_item)UIPackage.CreateObject("fun_Contract", "task_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n94 = (GGraph)GetChildAt(0);
            list = (GList)GetChildAt(1);
            goto_btn = (GButton)GetChildAt(2);
            get_btn = (GButton)GetChildAt(3);
            pro = (pro)GetChildAt(4);
            proLab = (GTextField)GetChildAt(5);
            titleLab = (GTextField)GetChildAt(6);
        }
    }
}