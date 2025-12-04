/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_SignInSevenDays
{
    public partial class SeventhSign_Item : GComponent
    {
        public Controller isLock;
        public Controller isToday;
        public GImage n31;
        public GImage n35;
        public GImage n36;
        public GImage n37;
        public GTextField gettedLab;
        public GTextField title;
        public GTextField getLab;
        public SeventhSign_Item1 reward;
        public const string URL = "ui://zrkg0kw288sqogs";

        public static SeventhSign_Item CreateInstance()
        {
            return (SeventhSign_Item)UIPackage.CreateObject("fun_SignInSevenDays", "SeventhSign_Item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            isLock = GetControllerAt(0);
            isToday = GetControllerAt(1);
            n31 = (GImage)GetChildAt(0);
            n35 = (GImage)GetChildAt(1);
            n36 = (GImage)GetChildAt(2);
            n37 = (GImage)GetChildAt(3);
            gettedLab = (GTextField)GetChildAt(4);
            title = (GTextField)GetChildAt(5);
            getLab = (GTextField)GetChildAt(6);
            reward = (SeventhSign_Item1)GetChildAt(7);
        }
    }
}