using Xunit;

namespace LanguageExt.Tests;

public class EitherOpticsTests
{
    [Fact]
    public void RightPrismGetShouldReturnValueForRight()
    {
        var expected = Option<int>.Some(123);
        var input = Either<string, int>.Right(123);

        var actual = Optics.Either<string,int>.right.Get(input);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void RightPrismGetShouldReturnNoneForLeft()
    {
        var expected = Option<int>.None;
        var input = Either<string, int>.Left("left");

        var actual = Optics.Either<string, int>.right.Get(input);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void RightPrismSetShouldReturnRightForRight()
    {
        var expected = Either<string, int>.Right(456);
        var input = Either<string, int>.Right(123);

        var actual = Optics.Either<string, int>.right.Set(456, input);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void RightPrismSetShouldReturnRightForLeft()
    {
        var expected = Either<string, int>.Right(456);
        var input = Either<string, int>.Left("left");

        var actual = Optics.Either<string, int>.right.Set(456, input);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void LeftPrismGetShouldReturnNoneForRight()
    {
        var expected = Option<string>.None;
        var input = Either<string, int>.Right(123);

        var actual = Optics.Either<string, int>.left.Get(input);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void LeftPrismGetShouldReturnUnitForLeft()
    {
        var expected = Option<string>.Some("left");
        var input = Either<string, int>.Left("left");

        var actual = Optics.Either<string, int>.left.Get(input);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void LeftPrismSetShouldReturnLeftForRight()
    {
        var expected = Either<string, int>.Left("modified");
        var input = Either<string, int>.Right(123);

        var actual = Optics.Either<string, int>.left.Set("modified", input);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void LeftPrismSetShouldReturnLeftForLeft()
    {
        var expected = Either<string, int>.Left("modified");
        var input = Either<string, int>.Left("left");

        var actual = Optics.Either<string, int>.left.Set("modified", input);

        Assert.Equal(expected, actual);
    }

}
