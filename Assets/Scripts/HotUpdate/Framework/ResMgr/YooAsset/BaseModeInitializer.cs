using YooAsset;
/// <summary>
/// 基础模式初始化器
/// </summary>
public abstract class BaseModeInitializer
{
    public abstract InitializeParameters Initialize();
    /// <summary>
    /// 远端资源地址查询服务类
    /// </summary>
    internal class RemoteServices : IRemoteServices
    {
        private readonly string _defaultHostServer;
        private readonly string _fallbackHostServer;

        public RemoteServices(string defaultHostServer, string fallbackHostServer)
        {
            _defaultHostServer = defaultHostServer;
            _fallbackHostServer = fallbackHostServer;
        }
        string IRemoteServices.GetRemoteMainURL(string fileName)
        {
            return $"{_defaultHostServer}/{fileName}";
        }
        string IRemoteServices.GetRemoteFallbackURL(string fileName)
        {
            return $"{_fallbackHostServer}/{fileName}";
        }
    }

    /// <summary>
    /// 获取资源服务器地址
    /// </summary>
    protected string GetHostServerURL()
    {
        return Config.cdnResPath + "/qmhj/wxRL/" + Config.appVer + "/StreamingAssets/yoo/DefaultPackage";
    }
}
