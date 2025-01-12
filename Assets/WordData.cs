[System.Serializable]
public class WordData
{
    public string word; // The word itself
    public string category; // "AI" or "Human"

    // Constructor to initialize the word and category
    public WordData(string word, string category)
    {
        this.word = word;
        this.category = category;
    }
}
