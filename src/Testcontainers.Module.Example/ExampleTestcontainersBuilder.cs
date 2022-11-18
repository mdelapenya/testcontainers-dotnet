namespace Testcontainers.Module.Example
{
  using System;
  using DotNet.Testcontainers.Builders;
  using DotNet.Testcontainers.Configurations;
  using Microsoft.Extensions.Logging.Abstractions;

  public sealed class ExampleTestcontainersBuilder : TestcontainersBuilder<ExampleTestcontainersBuilder, IExampleTestcontainers, IExampleTestcontainersConfiguration>
  {
    public ExampleTestcontainersBuilder()
      : base(new ExampleTestcontainersConfiguration())
    {
    }

    private ExampleTestcontainersBuilder(IExampleTestcontainersConfiguration dockerResourceConfiguration)
      : base(dockerResourceConfiguration)
    {
    }

    public ExampleTestcontainersBuilder WithUsername(string username)
    {
      return this.Clone(new ExampleTestcontainersConfiguration(username: username));
    }

    public ExampleTestcontainersBuilder WithPassword(string password)
    {
      return this.Clone(new ExampleTestcontainersConfiguration(password: password));
    }

    public override IExampleTestcontainers Build()
    {
      return new ExampleTestcontainers(this.DockerResourceConfiguration, NullLogger.Instance);
    }

    protected override ExampleTestcontainersBuilder Clone(IDockerResourceConfiguration dockerResourceConfiguration)
    {
      // Receives a configuration update from one of the base class implementations. The configuration update only contains properties from either one of the base class configuration types.
      // If we merge the configurations immediately we will lose any properties that are unknown by the base configuration:
      // E.g. for ITestcontainersConfiguration ⨉ IExampleTestcontainersConfiguration we will lose username and password. Due to immutable data we can only merge the same types.
      switch (dockerResourceConfiguration)
      {
        case ITestcontainersConfiguration testcontainersConfiguration:
          return this.Clone(new ExampleTestcontainersConfiguration(testcontainersConfiguration));
        default:
          return this.Clone(new ExampleTestcontainersConfiguration(dockerResourceConfiguration));
      }
    }

    protected override ExampleTestcontainersBuilder Clone(IExampleTestcontainersConfiguration dockerResourceConfiguration)
    {
      return new ExampleTestcontainersBuilder(new ExampleTestcontainersConfiguration(dockerResourceConfiguration, this.DockerResourceConfiguration));
    }
  }
}
