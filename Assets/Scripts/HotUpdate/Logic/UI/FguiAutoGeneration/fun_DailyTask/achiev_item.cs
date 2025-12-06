/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_DailyTask
{
    public partial class achiev_item : GComponent
    {
        public GImage n9;
        public pro pro;
        public GTextField nameLab;
        public GTextField decLab;
        public GTextField proLab;
        public GList reward_list;
        public btn getBtn;
        public const string URL = "ui://ueo46waaz1vi1ayr81u";

        public static achiev_item CreateInstance()
        {
            return (achiev_item)UIPackage.CreateObject("fun_DailyTask", "achiev_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n9 = (GImage)GetChildAt(0);
            pro = (pro)GetChildAt(1);
            nameLab = (GTextField)GetChildAt(2);
            decLab = (GTextField)GetChildAt(3);
            proLab = (GTextField)GetChildAt(4);
            reward_list = (GList)GetChildAt(5);
            getBtn = (btn)GetChildAt(6);
        }
    }
}