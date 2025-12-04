/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_GetReward
{
    public partial class getReward_item : GComponent
    {
        public GLoader bg;
        public GLoader pic;
        public GTextField txt_name;
        public GTextField txt_num;
        public GLoader3D spine;
        public const string URL = "ui://j0e2l4ppq9bj1yjp7sa";

        public static getReward_item CreateInstance()
        {
            return (getReward_item)UIPackage.CreateObject("fun_GetReward", "getReward_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            txt_name = (GTextField)GetChildAt(2);
            txt_num = (GTextField)GetChildAt(3);
            spine = (GLoader3D)GetChildAt(4);
        }
    }
}