using Flutter.Domain.Models;
using Xunit;

namespace Flutter.Testing
{
    public class PostTests
    {
        [Fact]
        private void Test_PostExists()
        {
            var sut = new Post(0,"testing");

            var actual = sut;

            Assert.IsType<Post>(actual);
            Assert.NotNull(actual);
        }
    }
}