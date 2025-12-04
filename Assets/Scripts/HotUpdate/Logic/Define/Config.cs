using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config
{
    public static string ApiHost = "http://192.168.3.53:8585/api";//彭震本地服
    //public static string ApiHost = "https://elida-api-test-v2.tigermoon.cn/api";//测试服
    //public static string ApiHost = "https://elida-api-test-stable.tigermoon.cn/api";//测试稳定服
    //public static string ApiHost = "https://elida-api-test.tigermoon.cn/api";//提审服
    public static string pid = "122_guohui";
    public static bool EnableNetLog = true;
    public static string cdnResPath = "https://elida-cdn.tigermoon.cn";
    public static string appVer = "v1.0.7";//app版本
    public static bool isShowLoginView = false;//是否显示登录界面(用于内部测试)
}

