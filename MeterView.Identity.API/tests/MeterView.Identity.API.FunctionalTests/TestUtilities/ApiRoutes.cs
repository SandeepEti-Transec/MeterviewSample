namespace MeterView.Identity.API.FunctionalTests.TestUtilities;
public class ApiRoutes
{
    public const string Base = "api";
    public const string Health = Base + "/health";

    // new api route marker - do not delete

    public static class UserRoles
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/userRoles";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/userRoles/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/userRoles/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/userRoles/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/userRoles/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/userRoles";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/userRoles/batch";
    }

    public static class Roles
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/roles";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/roles/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/roles/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/roles/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/roles/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/roles";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/roles/batch";
    }

    public static class UserOgranizations
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/userOgranizations";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/userOgranizations/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/userOgranizations/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/userOgranizations/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/userOgranizations/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/userOgranizations";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/userOgranizations/batch";
    }

    public static class Users
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/users";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/users/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/users/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/users/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/users/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/users";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/users/batch";
    }

    public static class Organizations
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/organizations";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/organizations/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/organizations/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/organizations/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/organizations/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/organizations";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/organizations/batch";
    }
}
