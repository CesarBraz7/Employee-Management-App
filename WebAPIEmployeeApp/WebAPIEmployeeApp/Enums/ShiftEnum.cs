using System.Text.Json.Serialization;

namespace WebAPIEmployeeApp.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ShiftEnum
    {
        Morning,
        Afternoon,
        Night
    }
}
