using System;
using System.Collections.Generic;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(string reference, string text)
    {
        _reference = new Reference(reference);
        _words = new List<Word>();

        // Convert each word into a Word object
        string[] words = text.Split(' ');
        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
    }

    public void Display()
    {
        Console.WriteLine(_reference);
        foreach (Word word in _words)
        {
            Console.Write(word + " ");
        }
        Console.WriteLine();
    }

    public void HideWords(int count)
    {
        // Get a list of words that are still visible
        List<Word> visibleWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (!word.IsHidden)
            {
                visibleWords.Add(word);
            }
        }

        // If no words left to hide, exit
        if (visibleWords.Count == 0) return;

        // Hide random words
        int wordsToHide = Math.Min(count, visibleWords.Count);
        for (int i = 0; i < wordsToHide; i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index); // Remove from list so it's not picked again
        }
    }

    public bool IsFullyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden) return false;
        }
        return true;
    }

    public void RevealWord()
    {
        // Get a list of words that are hidden
        List<Word> hiddenWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (word.IsHidden)
            {
                hiddenWords.Add(word);
            }
        }

        // Reveal a random hidden word
        if (hiddenWords.Count > 0)
        {
            int index = _random.Next(hiddenWords.Count);
            hiddenWords[index].Reveal();
        }
    }
}
