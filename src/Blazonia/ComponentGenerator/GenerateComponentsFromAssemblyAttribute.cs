namespace Blazonia.ComponentGenerator;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
public class GenerateComponentsFromAssemblyAttribute : Attribute
{
    public GenerateComponentsFromAssemblyAttribute(string assemblyName) { }

    public string TypeNamePrefix { get; set; }
}