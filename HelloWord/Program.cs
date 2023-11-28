using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWord
{
    class Program
    {
        //static void Main(string[] args)
        //{     
        //    //Trong Si Pham 04.05.2023
        //    Console.WriteLine("Hello World");

        //    string aFriend = "Bill";
        //    Console.WriteLine(aFriend);

        //    Console.WriteLine($"Hello {aFriend}");

        //    string firstFriend = "Maria";
        //    string secondFriend = "Sage";
        //    Console.WriteLine($"My friends are {firstFriend} and {secondFriend}");

        //    Console.WriteLine($"The name {firstFriend} has {firstFriend.Length} letters.");
        //    Console.WriteLine($"The name {secondFriend} has {secondFriend.Length} letters.");

        //    string helloworld = "        Hello World!      ";
        //    Console.WriteLine($"[{helloworld}]");

        //    string trimhelloworld = helloworld.Trim();
        //    Console.WriteLine($"[{trimhelloworld}]");

        //    string trimendhelloworld = helloworld.TrimEnd();
        //    Console.WriteLine($"[{trimendhelloworld}]");

        //    string trimstarthelloworld = helloworld.TrimStart();
        //    Console.WriteLine($"[{trimstarthelloworld}]");

        //    string sayHello = "Hello World!";
        //    Console.WriteLine(sayHello);
        //    sayHello = sayHello.Replace("Hello", "Greetings");
        //    Console.WriteLine(sayHello);

        //    Console.WriteLine(sayHello.ToUpper());
        //    Console.WriteLine(sayHello.ToLower());

        //    string songLyrics = "You say goodbye, and I say hello";
        //    Console.WriteLine(songLyrics.Contains("goodbye"));
        //    Console.WriteLine(songLyrics.Contains("greetings"));


        //    Console.WriteLine(songLyrics.StartsWith("You"));
        //    Console.WriteLine(songLyrics.StartsWith("goodbye"));

        //    Console.WriteLine(songLyrics.EndsWith("hello"));
        //    Console.WriteLine(songLyrics.EndsWith("goodbye"));
        //}



        int main()
        {
            Stream inputFile("Kennedy.txt");
            map<string, vector<int>> wordMap;

            string line;
            int lineNumber = 1;

            // Read the input file line by line
            while (getline(inputFile, line))
            {
                istringstream iss(line);
                string word;

                // Tokenize each line into individual words
                while (iss >> word)
                {
                    wordMap[word].push_back(lineNumber);
                }

                lineNumber++;
            }

            inputFile.close();

            // Create the word index file
            ofstream outputFile("OutputFile.txt");

            // Iterate over the word map and write the word index to the output file
            for (const auto&pair : wordMap) {
                string word = pair.first;
                vector<int> lineNumbers = pair.second;

                // Remove duplicate line numbers
                sort(lineNumbers.begin(), lineNumbers.end());
                lineNumbers.erase(unique(lineNumbers.begin(), lineNumbers.end()), lineNumbers.end());

                // Write the word and its associated line numbers to the output file
                outputFile << word << ": ";
                for (int i = 0; i < lineNumbers.size(); i++)
                {
                    outputFile << lineNumbers[i];
                    if (i != lineNumbers.size() - 1)
                    {
                        outputFile << " ";
                    }
                }
                outputFile << "\n";
            }

            outputFile.close();

            // Display the word index on the console
            ifstream wordIndexFile("WordIndex.txt");
            cout << "Word Index:\n";
            cout << wordIndexFile.rdbuf();

            wordIndexFile.close();

            return 0;
        }

    }
}
