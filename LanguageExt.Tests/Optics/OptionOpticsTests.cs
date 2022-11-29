using Xunit;
using static LanguageExt.Prelude;

namespace LanguageExt.Tests
{
    public class OptionOpticsTests
    {
        [Fact]
        public void SomePrismGetShouldReturnValueForSome()
        {
            var expected = Some(123);
            var input = Some(123);

            var actual = Optics.Option<int>.some.Get(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SomePrismGetShouldReturnNoneForNone()
        {
            var expected = Option<int>.None;
            var input = Option<int>.None;

            var actual = Optics.Option<int>.some.Get(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SomePrismSetShouldReturnSomeForSome()
        {
            var expected = Some(456);
            var input = Some(123);

            var actual = Optics.Option<int>.some.Set(456, input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SomePrismSetShouldReturnSomeForNone()
        {
            var expected = Some(456);
            var input = Option<int>.None;

            var actual = Optics.Option<int>.some.Set(456, input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NonePrismGetShouldReturnNoneForSome()
        {
            var expected = Option<Unit>.None;
            var input = Some(123);

            var actual = Optics.Option<int>.none.Get(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NonePrismGetShouldReturnUnitForNone()
        {
            var expected = Some(Unit.Default);
            var input = Option<int>.None;

            var actual = Optics.Option<int>.none.Get(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NonePrismSetShouldReturnNoneForSome()
        {
            var expected = Option<int>.None;
            var input = Some(123);

            var actual = Optics.Option<int>.none.Set(Unit.Default, input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NonePrismSetShouldReturnNoneForNone()
        {
            var expected = Option<int>.None;
            var input = Option<int>.None;

            var actual = Optics.Option<int>.none.Set(Unit.Default, input);

            Assert.Equal(expected, actual);
        }

    }
}
