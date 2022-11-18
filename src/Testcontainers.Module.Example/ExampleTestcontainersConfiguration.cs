namespace Testcontainers.Module.Example
{
  using DotNet.Testcontainers.Builders;
  using DotNet.Testcontainers.Configurations;

  internal sealed class ExampleTestcontainersConfiguration : TestcontainersConfiguration, IExampleTestcontainersConfiguration
  {
    // This is the default configuration.
    public ExampleTestcontainersConfiguration()
    {
    }

    // Forwards and sets the base configuration.
    public ExampleTestcontainersConfiguration(IDockerResourceConfiguration dockerResourceConfiguration)
      : base(dockerResourceConfiguration)
    {
    }

    // Forwards and sets the base configuration.
    public ExampleTestcontainersConfiguration(ITestcontainersConfiguration dockerResourceConfiguration)
      : base(dockerResourceConfiguration)
    {
    }

    // Merges the configuration.
    public ExampleTestcontainersConfiguration(IExampleTestcontainersConfiguration next, IExampleTestcontainersConfiguration previous)
      : base(next, previous)
    {
      this.Username = BuildConfiguration.Combine(next.Username, previous.Username);
      this.Password = BuildConfiguration.Combine(next.Password, previous.Password);
    }

    // TODO: Check the different configuration implementations and their constructors.
    // E.g. ExampleTestcontainersConfiguration vs. TestcontainersConfiguration.
    // Do they share and follow a common pattern? Can we reduce the constructor calls?
    public ExampleTestcontainersConfiguration(
      string username = null,
      string password = null)
    {
      this.Username = username;
      this.Password = password;
    }

    public string Username { get; }

    public string Password { get; }
  }
}
