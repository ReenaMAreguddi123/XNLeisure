using XNLeisure.Business;
using Xunit;

namespace XNLeisureTests
{
    public class CharacterCountTest
    {
        [Fact]
        public void CharacterCount_Sentence()
        {
            //Arrange
            var sentence =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Eanean sodales justo et Enim ornare, a congue lacus commodo.";
            var lookFor = 'e';

            //Act
            var characterCount = new CharacterCount();
            var result = characterCount.Count(sentence, lookFor);

            //Assert
            Assert.True(result == 10);
        }

        [Fact]
        public void CharacterCount_Number()
        {
            //Arrange
            var sentence = "17272838119191929838299111";
            var lookFor = '1';

            //Act
            var characterCount = new CharacterCount();
            var result = characterCount.Count(sentence, lookFor);

            //Assert
            Assert.True(result == 8);
        }
    }
}
