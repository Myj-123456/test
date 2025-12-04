/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class dress_call_result : GComponent
    {
        public Controller status;
        public dress_call_result_item item0;
        public dress_call_result_item item1;
        public dress_call_result_item item2;
        public dress_call_result_item item3;
        public dress_call_result_item item4;
        public dress_call_result_item item5;
        public dress_call_result_item item6;
        public dress_call_result_item item7;
        public dress_call_result_item item8;
        public dress_call_result_item item9;
        public const string URL = "ui://argzn455m3gh1o";

        public static dress_call_result CreateInstance()
        {
            return (dress_call_result)UIPackage.CreateObject("fun_Dress", "dress_call_result");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            item0 = (dress_call_result_item)GetChildAt(0);
            item1 = (dress_call_result_item)GetChildAt(1);
            item2 = (dress_call_result_item)GetChildAt(2);
            item3 = (dress_call_result_item)GetChildAt(3);
            item4 = (dress_call_result_item)GetChildAt(4);
            item5 = (dress_call_result_item)GetChildAt(5);
            item6 = (dress_call_result_item)GetChildAt(6);
            item7 = (dress_call_result_item)GetChildAt(7);
            item8 = (dress_call_result_item)GetChildAt(8);
            item9 = (dress_call_result_item)GetChildAt(9);
        }
    }
}