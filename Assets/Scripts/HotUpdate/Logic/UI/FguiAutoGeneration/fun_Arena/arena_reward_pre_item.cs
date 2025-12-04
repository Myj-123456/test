/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Arena
{
    public partial class arena_reward_pre_item : GComponent
    {
        public Controller gradeTab;
        public Controller theLastOne;
        public GImage n69;
        public GImage n71;
        public GImage n70;
        public GComponent grid;
        public GList rewardList;
        public GTextField rankNum;
        public GTextField titleNameTxt;
        public const string URL = "ui://dz2e3lzav5lj1yjp7vi";

        public static arena_reward_pre_item CreateInstance()
        {
            return (arena_reward_pre_item)UIPackage.CreateObject("fun_Arena", "arena_reward_pre_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            gradeTab = GetControllerAt(0);
            theLastOne = GetControllerAt(1);
            n69 = (GImage)GetChildAt(0);
            n71 = (GImage)GetChildAt(1);
            n70 = (GImage)GetChildAt(2);
            grid = (GComponent)GetChildAt(3);
            rewardList = (GList)GetChildAt(4);
            rankNum = (GTextField)GetChildAt(5);
            titleNameTxt = (GTextField)GetChildAt(6);
        }
    }
}