/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_DailyTask
{
    public partial class pro_com : GComponent
    {
        public dailyTaskProgress pro;
        public const string URL = "ui://ueo46waaz1vi1ayr81o";

        public static pro_com CreateInstance()
        {
            return (pro_com)UIPackage.CreateObject("fun_DailyTask", "pro_com");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            pro = (dailyTaskProgress)GetChildAt(0);
        }
    }
}