namespace Dit.Umb.Mutobo.Interfaces
{
    public interface IConfigurationService
    {
        string GetAppSettingValue(string key, bool essential = true);
        int? GetAppSettingIntValue(string key, bool essential = true);
        bool? GetAppSettingBoolValue(string key, bool essential = true);
    }
}
