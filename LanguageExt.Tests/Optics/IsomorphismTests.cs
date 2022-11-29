using Xunit;
using static LanguageExt.Prelude;

namespace LanguageExt.Tests
{
    public class IsomorphismTests
    {
        internal static readonly Isomorphism<string, Seq<char>> stringSeqIsomorphism =
            Isomorphism<string, Seq<char>>.New(
                Get: s => s.ToSeq(),
                Set: c => new string(c.ToArray())
            );
        
        [Fact]
        public void GetShouldConvert()
        {
            var expected = Seq('1', '2', '3');
            var input = "123";

            var actual = stringSeqIsomorphism.Get(input);

            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void SetShouldConvert()
        {
            var expected = "123";
            var input = Seq('1', '2', '3');

            var actual = stringSeqIsomorphism.Set(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UpdateShouldModifyValue()
        {
            var expected = "123X";
            var input = "123";

            var actual = stringSeqIsomorphism.Update(x => x.Add('X'), input);

            Assert.Equal(expected, actual);
        }
    }


}
