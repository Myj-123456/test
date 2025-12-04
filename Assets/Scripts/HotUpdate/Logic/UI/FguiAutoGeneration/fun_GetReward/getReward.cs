/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_GetReward
{
    public partial class getReward : GComponent
    {
        public Controller status;
        public GLoader3D spine;
        public GLoader n38;
        public getReward_list content;
        public GTextField close_btn;
        public GTextField n47;
        public GImage n48;
        public GImage n49;
        public GImage n50;
        public GGroup n51;
        public Transition anim;
        public const string URL = "ui://j0e2l4ppq9bj1yjp7s8";

        public static getReward CreateInstance()
        {
            return (getReward)UIPackage.CreateObject("fun_GetReward", "getReward");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            spine = (GLoader3D)GetChildAt(0);
            n38 = (GLoader)GetChildAt(1);
            content = (getReward_list)GetChildAt(2);
            close_btn = (GTextField)GetChildAt(3);
            n47 = (GTextField)GetChildAt(4);
            n48 = (GImage)GetChildAt(5);
            n49 = (GImage)GetChildAt(6);
            n50 = (GImage)GetChildAt(7);
            n51 = (GGroup)GetChildAt(8);
            anim = GetTransitionAt(0);
        }
    }
}