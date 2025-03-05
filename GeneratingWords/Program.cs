using System.IO;
using System;
namespace GeneratingWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string wordsFilePath = "words.txt";

            string[] hiddenWords = { "AnimalProducts", "DinoEgg", "DuckEgg", "DuckFeather", "Egg", "GoatMilk", "GoldenEgg", "OstrichEgg", "RabbitsFoot", "Roe", "Slime", "SlimeBall", "Truffle", "Wool", "VoidEgg", "LargeEgg", "  ",
             "Cooking", "Bread", "Chowder", "Coleslaw", "Cookie", "CrabCakes", "FishTaco", "FriedEel", "Hashbrowns", "IceCream", "MakiRoll", "MinersTreat", "MossSoup", "Omelet", "Pancakes", "MapleBar", "  ",
            "Fish", "PufferFish", "Anchovy", "Tuna", "Sardine", "Bream", "Salmon", "Walleye", "Perch", "Carp", "Catfish", "Pike", "Herring", "Sunfish", "Eel", "Squid", "  ",
              "Crops", "BlueJazz", "Carrot", "Garlic", "Kale", "Parsnip", "Potato", "Rhubarb", "Tulip", "Rice", "Corn", "Hops", "Melon", "Poppy", "Radish", "Starfruit", "  ",
              "SwordUpgrades", "Rusty", "Steel", "Wooden", "Pirates", "SilverSaber", "Cutlass", "Forest", "IronEdge", "InsectHead", "Bone", "Claymore", "HolyBlade", "YetiTooth", "Dark", "Dwarf", "  ",
            "Rings", "Glow", "Magnet", "SlimeCharmer", "Warrior", "Vampire", "Savage", "RingOfYoba", "Sturdy", "Burglars", "IridumBand", "JukeBox", "Amethyst", "Topaz", "Emerald", "Jade", "  ",
             "Hats", "Cowboy", "Fashion", "Cone", "Chef", "Straw", "Trucker", "Fedora", "Party", "Santa", "Dinosaur", "Panda", "Pirate", "CatEars", "CowGal", "Arcane", "  ",
            "Boots", "Thermal", "Rubber", "Work", "Dark", "Cowboy", "Tundra", "Combat", "FireWalker", "Space", "Mermaid", "Dragonscale", "EmilysMagic", "Crystal", "Genie", "Leprechaun", "  ",
             "Villigers", "Alex", "Leo", "Sam", "Krobus", "Emily", "Haley", "Linus", "Maru", "Penny", "Sandy", "Dwarf", "Pam", "Gus", "Robin", "Jodi", "  ",
              "Animals", "Dog", "Cat", "Turtle", "Chicken", "Duck", "Rabbit", "Dinosaur", "Cow", "Goat", "Sheep", "Pig", "Ostrich", "Frog", "Owl", "Parrot", };
            File.WriteAllLines(wordsFilePath, hiddenWords);
        }
    }
}
