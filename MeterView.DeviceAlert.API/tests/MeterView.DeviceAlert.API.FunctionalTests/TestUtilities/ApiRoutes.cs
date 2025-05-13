namespace MeterView.DeviceAlert.API.FunctionalTests.TestUtilities;
public class ApiRoutes
{
    public const string Base = "api";
    public const string Health = Base + "/health";

    // new api route marker - do not delete

    public static class DeviceAlerts
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/deviceAlerts";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/deviceAlerts/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/deviceAlerts/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/deviceAlerts/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/deviceAlerts/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/deviceAlerts";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/deviceAlerts/batch";
    }
}
