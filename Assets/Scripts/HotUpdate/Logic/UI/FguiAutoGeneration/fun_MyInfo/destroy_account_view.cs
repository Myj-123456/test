/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class destroy_account_view : GComponent
    {
        public GLoader bg;
        public GButton close_btn;
        public GImage n3;
        public GTextField titileLab;
        public txtListItem1 content;
        public GButton reject_btn;
        public agreeBtn agree_btn;
        public const string URL = "ui://ehkqmfbprb3e1yjp844";

        public static destroy_account_view CreateInstance()
        {
            return (destroy_account_view)UIPackage.CreateObject("fun_MyInfo", "destroy_account_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            close_btn = (GButton)GetChildAt(1);
            n3 = (GImage)GetChildAt(2);
            titileLab = (GTextField)GetChildAt(3);
            content = (txtListItem1)GetChildAt(4);
            reject_btn = (GButton)GetChildAt(5);
            agree_btn = (agreeBtn)GetChildAt(6);
        }
    }
}