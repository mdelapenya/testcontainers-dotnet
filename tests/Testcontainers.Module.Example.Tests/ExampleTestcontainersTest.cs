namespace Testcontainers.Module.Example.Tests
{
  using DotNet.Testcontainers.Images;
  using Xunit;

  public sealed class ExampleTestcontainersTest
  {
    private const string Username = "Foo";

    private const string Password = "Bar";

    private static readonly IDockerImage Image = new DockerImage("httpd");

    private readonly IExampleTestcontainers testcontainers = new ExampleTestcontainersBuilder()
      .WithUsername(string.Empty)
      .WithLabel("Foo", "Bar")
      .WithPassword(string.Empty)
      .WithImage(Image)
      .WithUsername(Username)
      .WithPassword(Password)
      .Build();

    // private readonly ITestcontainersContainer testcontainers2 = new TestcontainersBuilder()
    //   .WithImage(Image)
    //   .Build();

    // This should not be necessary in the future, it is obsolete.
    // private readonly ITestcontainersContainer testcontainers3 = new TestcontainersBuilder<ITestcontainersContainer>()
    //   .WithImage(Image)
    //   .Build();

    [Fact]
    public void ShouldSetUsernameAndPassword()
    {
      Assert.Equal(Username, this.testcontainers.Username);
      Assert.Equal(Password, this.testcontainers.Password);
    }

    [Fact]
    public void ShouldCreateCopyOfBuilderConfiguration()
    {
      var baseBuilder = new ExampleTestcontainersBuilder()
        .WithUsername(Username)
        .WithPassword(Password);

      var container1 = baseBuilder
        .WithPassword(string.Empty)
        .Build();

      var container2 = baseBuilder
        .Build();

      Assert.Equal(Username, container1.Username);
      Assert.Equal(Username, container2.Username);
      Assert.Equal(string.Empty, container1.Password);
      Assert.Equal(Password, container2.Password);
    }
  }
}
