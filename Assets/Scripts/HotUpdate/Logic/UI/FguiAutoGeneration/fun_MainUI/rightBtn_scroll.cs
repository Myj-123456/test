/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MainUI
{
    public partial class rightBtn_scroll : GComponent
    {
        public Controller status;
        public funRightBtn btn_welfare;
        public funRightBtn btn_inviteGift;
        public funRightBtn btn_videoRevenue;
        public funRightBtn btn_dailyActivities;
        public GGroup btn_grp;
        public const string URL = "ui://fa0hi8ybu25n1ayr84h";

        public static rightBtn_scroll CreateInstance()
        {
            return (rightBtn_scroll)UIPackage.CreateObject("fun_MainUI", "rightBtn_scroll");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            btn_welfare = (funRightBtn)GetChildAt(0);
            btn_inviteGift = (funRightBtn)GetChildAt(1);
            btn_videoRevenue = (funRightBtn)GetChildAt(2);
            btn_dailyActivities = (funRightBtn)GetChildAt(3);
            btn_grp = (GGroup)GetChildAt(4);
        }
    }
}