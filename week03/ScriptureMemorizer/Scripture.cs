using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference reference;
    private List<Word> words;

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        words = new List<Word>();
        foreach (string word in text.Split(' '))
        {
            words.Add(new Word(word));
        }
    }

    public void Display()
    {
        Console.WriteLine(reference.GetDisplayText());
        foreach (Word word in words)
        {
            Console.Write(word.GetDisplayText() + " ");
        }
        Console.WriteLine();
    }

    public void HideRandomWords(Random random, int count = 2)
    {
        for (int i = 0; i < count; i++)
        {
            int index = random.Next(words.Count);
            words[index].Hide();
        }
    }

    public bool AreAllWordsHidden()
    {
        foreach (Word word in words)
        {
            if (!word.IsHidden())
                return false;
        }
        return true;
    }
}
