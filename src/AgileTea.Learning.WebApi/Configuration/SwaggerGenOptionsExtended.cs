using System.Reflection;

namespace AgileTea.Learning.WebApi.Configuration
{
    public class SwaggerGenOptionsExtended
    {
        public string? ApplicationTitle { get; set; } = Assembly.GetEntryAssembly()?.GetName().Name;
    }
}
