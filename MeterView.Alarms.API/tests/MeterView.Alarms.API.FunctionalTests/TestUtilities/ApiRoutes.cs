namespace MeterView.Alarms.API.FunctionalTests.TestUtilities;
public class ApiRoutes
{
    public const string Base = "api";
    public const string Health = Base + "/health";

    // new api route marker - do not delete

    public static class Alarms
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/alarms";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/alarms/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/alarms/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/alarms/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/alarms/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/alarms";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/alarms/batch";
    }
}
