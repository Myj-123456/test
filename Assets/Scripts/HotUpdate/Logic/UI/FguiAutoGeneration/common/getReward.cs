/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common
{
    public partial class getReward : GComponent
    {
        public GImage n29;
        public GList list;
        public GTextField txt_tip;
        public blueBtn btn_confirm;
        public CloseBtn close_btn;
        public const string URL = "ui://6bdpq80ku0i31yjp7s5";

        public static getReward CreateInstance()
        {
            return (getReward)UIPackage.CreateObject("common", "getReward");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n29 = (GImage)GetChildAt(0);
            list = (GList)GetChildAt(1);
            txt_tip = (GTextField)GetChildAt(2);
            btn_confirm = (blueBtn)GetChildAt(3);
            close_btn = (CloseBtn)GetChildAt(4);
        }
    }
}