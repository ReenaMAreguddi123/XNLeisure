using System.Linq;

namespace XNLeisure.Business
{
    public  class CharacterCount
    {
        public int Count(string sentence, char lookFor)
        {
            if (string.IsNullOrWhiteSpace(sentence))
                return 0;

            return sentence.Count(x => (x == lookFor));
        }
    }
}
