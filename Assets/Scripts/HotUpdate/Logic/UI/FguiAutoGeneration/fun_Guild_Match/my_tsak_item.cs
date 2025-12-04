/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_Match
{
    public partial class my_tsak_item : GComponent
    {
        public Controller status;
        public GImage n5;
        public GImage n6;
        public GRichTextField score_txt;
        public GTextField scoreLab;
        public GList rewardList;
        public GButton getBtn;
        public GButton showBtn;
        public const string URL = "ui://qefze8qitewh7";

        public static my_tsak_item CreateInstance()
        {
            return (my_tsak_item)UIPackage.CreateObject("fun_Guild_Match", "my_tsak_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n5 = (GImage)GetChildAt(0);
            n6 = (GImage)GetChildAt(1);
            score_txt = (GRichTextField)GetChildAt(2);
            scoreLab = (GTextField)GetChildAt(3);
            rewardList = (GList)GetChildAt(4);
            getBtn = (GButton)GetChildAt(5);
            showBtn = (GButton)GetChildAt(6);
        }
    }
}