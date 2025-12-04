/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class NoticeScrollListItem : GComponent
    {
        public Controller type;
        public GTextField levelLab;
        public GTextField timeLab;
        public GTextField seedLab;
        public GTextField flowerLab;
        public GTextField countLab;
        public const string URL = "ui://ekoic0wrqheb1yjp7mt";

        public static NoticeScrollListItem CreateInstance()
        {
            return (NoticeScrollListItem)UIPackage.CreateObject("fun_CultivationManual_new", "NoticeScrollListItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            levelLab = (GTextField)GetChildAt(0);
            timeLab = (GTextField)GetChildAt(1);
            seedLab = (GTextField)GetChildAt(2);
            flowerLab = (GTextField)GetChildAt(3);
            countLab = (GTextField)GetChildAt(4);
        }
    }
}