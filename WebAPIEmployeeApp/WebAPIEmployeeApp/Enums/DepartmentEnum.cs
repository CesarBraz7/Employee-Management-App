using System.Text.Json.Serialization;

namespace WebAPIEmployeeApp.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartmentEnum
    {
        HR,
        Financial,
        Purchasing,
        Janitorial
    }
}
