/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Tour_Land
{
    public partial class proComonent : GComponent
    {
        public GImage n0;
        public GImage pro_img;
        public box_reward reward1;
        public box_reward reward2;
        public box_reward reward3;
        public box_reward reward4;
        public const string URL = "ui://oo5kr0yot5nhg";

        public static proComonent CreateInstance()
        {
            return (proComonent)UIPackage.CreateObject("fun_Tour_Land", "proComonent");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            pro_img = (GImage)GetChildAt(1);
            reward1 = (box_reward)GetChildAt(2);
            reward2 = (box_reward)GetChildAt(3);
            reward3 = (box_reward)GetChildAt(4);
            reward4 = (box_reward)GetChildAt(5);
        }
    }
}