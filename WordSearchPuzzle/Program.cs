using System.IO;
using System;
namespace WordSearchPuzzle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader selection = new StreamReader("words.txt");
            string hiddenWords = selection.ReadToEnd();
            string[] splitCategories = hiddenWords.Split("\r\n");
            string[] categories = new string[10];
            string[][] categoryWords = new string[10][];
            Random rmd = new Random();
            string[] eightWords = new string[8];
            int eightWordsIndex = 0;
            //using each category with the words inside.
            for (int i = 0, j = 0; i < 10; i++, j += 17)
            {
                categories[i] = splitCategories[j];
                categoryWords[i] = new string[15];

                for (int k = 0; k < 15 && (j + k) + 1 < splitCategories.Length; k++)
                {
                    categoryWords[i][k] = splitCategories[(j + k) + 1];
                }
                Console.WriteLine(categories[i]);
            }
            bool isSelecting = true;
            string selectingCategory = " ";
            //checking if the user is choosing a correct category, if not it repeats the WriteLine.
            while (isSelecting)
            {
                Console.WriteLine("Please choose one of the categories");
                string? stringInput = Console.ReadLine();

                for (int i = 0; i < categories.Length; i++)
                {
                    if (stringInput != null && stringInput.Equals(categories[i]))
                    {
                        selectingCategory = categories[i];
                        Console.WriteLine("You have chosen " + selectingCategory);
                        isSelecting = false;
                        break;
                    }
                }
            }
            int selectedCategoryIndex = 1;
            for (int i = 0; i < categories.Length; i++)
            {
                if (categories[i] == selectingCategory)
                {
                    selectedCategoryIndex = i;
                    break;
                }
            }
            string[] wordsInSelectedCate = categoryWords[selectedCategoryIndex];
            //putting the 15 words chosen into 8 of them randomly. 
            while (eightWordsIndex < 8)
            {
                string words = wordsInSelectedCate[rmd.Next(wordsInSelectedCate.Length)];
                bool wordisThere = false;
                for (int i = 0; i < eightWordsIndex; i++)
                {
                    if (eightWords[i] == words)
                    {
                        wordisThere = true;
                        break;
                    }
                }
                if (!wordisThere)
                {
                    eightWords[eightWordsIndex] = words;
                    eightWordsIndex++;
                }
            }
            //outputting the 8 words chosen in the category user has picked
            foreach (string word in eightWords)
            {
                Console.WriteLine(word);
            }
            //creating a word search with char's 
            char[,] wordSearch = new char[20, 20];
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    wordSearch[i, j] = '.';
                }
            }
            //checking if the word can be placed
            bool CanPlace(string word, int row, int col, bool isHorizontal)
            {
                bool canPlace = true;
                if (isHorizontal)
                {
                    if (col + word.Length > 20)
                    {
                        canPlace = false;
                    }
                    else
                    {
                        for (int i = 0; i < word.Length; i++)
                        {
                            if (wordSearch[row, col + i] != '.')
                            {
                                canPlace = false;
                                break;
                            }
                        }
                    }
                }
                else   // vertical 
                {
                    if (row + word.Length > 20)
                    {
                        canPlace = false;
                    }
                    else
                    {
                        for (int i = 0; i < word.Length; i++)
                        {
                            if (wordSearch[row + i, col] != '.')
                            {
                                canPlace = false;
                                break;
                            }
                        }
                    }
                }
                return canPlace;
            }
            // if can be placed, then puts the word in a random row/ column , vertical or horzional. 
            void WordsPlaced(string word, int row, int col, bool isHorizontal)
            {
                if (isHorizontal)
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        wordSearch[row, col + i] = word[i];
                    }
                }
                else // vertical 
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        wordSearch[row + i, col] = word[i];
                    }
                }
            }
            // using the words in eightWords to check if that word can be placed before placing it
            foreach (string word in eightWords)
            {
                bool isPlaced = false;
                while (!isPlaced)
                {
                    int row = rmd.Next(20);
                    int col = rmd.Next(20);
                    bool isHorizontal = rmd.Next(2) == 0;
                    if (CanPlace(word, row, col, isHorizontal))
                    {
                        WordsPlaced(word, row, col, isHorizontal);
                        isPlaced = true;
                    }
                }
            }
            //outputting the wordsearch to the user with the words in. 
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (wordSearch[i, j] == '.')
                    {
                        wordSearch[i, j] = (char)rmd.Next('A', 'Z' + 1);
                    }
                }
            }
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Console.Write(wordSearch[i, j]);
                }
                Console.WriteLine();
            }
            //outputting the 8 words chosen in the category user has picked
            Console.WriteLine("Find the words:");
            foreach (string word in eightWords)
            {
                Console.WriteLine(word);
            }

            int wordsFound = 0;
            //tracking which words to be found.

            while (wordsFound < 8)
            {
                Console.WriteLine("Enter a word found");
                string? userInput = Console.ReadLine();

                if (userInput != null)
                {
                    for (int i = 0; i < eightWords.Length; i++)
                    {
                        if (userInput == eightWords[i])
                        {
                            wordsFound++;
                            Console.WriteLine("You found " + userInput);
                            break;
                        }
                    }
                    if (wordsFound == 8)
                    {
                        Console.WriteLine("You found all the words.");
                    }
                }
            }
        }
    }
}






