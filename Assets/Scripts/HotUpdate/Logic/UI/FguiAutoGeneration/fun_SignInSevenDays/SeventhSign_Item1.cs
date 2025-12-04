/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_SignInSevenDays
{
    public partial class SeventhSign_Item1 : GComponent
    {
        public GImage n11;
        public GLoader img_reward;
        public GTextField num;
        public const string URL = "ui://zrkg0kw288sqogt";

        public static SeventhSign_Item1 CreateInstance()
        {
            return (SeventhSign_Item1)UIPackage.CreateObject("fun_SignInSevenDays", "SeventhSign_Item1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n11 = (GImage)GetChildAt(0);
            img_reward = (GLoader)GetChildAt(1);
            num = (GTextField)GetChildAt(2);
        }
    }
}