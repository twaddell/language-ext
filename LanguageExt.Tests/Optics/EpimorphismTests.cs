using Xunit;
using static LanguageExt.Prelude;

namespace LanguageExt.Tests
{
    public class EpimorphismTests
    {
        internal static readonly Epimorphism<string, int> stringIntEpimorphism =
            Epimorphism<string, int>.New(
                Get: parseInt,
                Set: i => i.ToString()
            );

        [Fact]
        public void GetCanConvertToSome()
        {
            var expected = Some(123);
            var input = "123";

            var actual = stringIntEpimorphism.Get(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetCanConvertToNone()
        {
            var expected = Option<int>.None;
            var input = "Not an integer";

            var actual = stringIntEpimorphism.Get(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SetShouldConvert()
        {
            var expected = "123";
            var input = 123;

            var actual = stringIntEpimorphism.Set(input);

            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void UpdateShouldModifyValidValue()
        {
            var expected = "133";
            var input = "123";

            var actual = stringIntEpimorphism.Update(x => x + 10, input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UpdateShouldReturnOriginalValueForInvalidValue()
        {
            var expected = "Not an integer";
            var input = "Not an integer";

            var actual = stringIntEpimorphism.Update(x => x + 10, input);

            Assert.Equal(expected, actual);
        }
    }
}
