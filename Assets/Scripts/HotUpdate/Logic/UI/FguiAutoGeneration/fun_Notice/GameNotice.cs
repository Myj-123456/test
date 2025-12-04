/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Notice
{
    public partial class GameNotice : GComponent
    {
        public Controller status;
        public Controller have;
        public GLoader bg;
        public GImage n62;
        public GImage n59;
        public GTextField titleLab;
        public GGroup n60;
        public GTextField pageTxt;
        public GList pageList;
        public CloseBtn close_btn;
        public GButton leftBtn;
        public GButton rightBtn;
        public const string URL = "ui://6ijclyxxm89jvgk2oa";

        public static GameNotice CreateInstance()
        {
            return (GameNotice)UIPackage.CreateObject("fun_Notice", "GameNotice");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            have = GetControllerAt(1);
            bg = (GLoader)GetChildAt(0);
            n62 = (GImage)GetChildAt(1);
            n59 = (GImage)GetChildAt(2);
            titleLab = (GTextField)GetChildAt(3);
            n60 = (GGroup)GetChildAt(4);
            pageTxt = (GTextField)GetChildAt(5);
            pageList = (GList)GetChildAt(6);
            close_btn = (CloseBtn)GetChildAt(7);
            leftBtn = (GButton)GetChildAt(8);
            rightBtn = (GButton)GetChildAt(9);
        }
    }
}