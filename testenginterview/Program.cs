using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace testenginterview
{

    class bigramlib
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine(@"No file to input: example( testenginterview C:\testfile )");
                System.Console.ReadKey();
                return;
            }
            try
            {
                string text = System.IO.File.ReadAllText(args[0]);
                List<string> output = bigramlib.biGrams(text);
                if (output.Count > 0)
                {
                    output.Sort();
                    var lastKey = output[0];
                    var lastCount = 0;
                    foreach (var bigram in output)
                    {
                        if (bigram == lastKey)
                        {
                            lastCount++;
                        }
                        else
                        {
                            Console.WriteLine("\"{0}\" {1}", lastKey, lastCount);
                            lastKey = bigram;
                            lastCount = 1;
                        }
                    }
                    Console.WriteLine("\"{0}\" {1}", lastKey, lastCount);
                }
                else
                {
                    Console.WriteLine("no bigrams found");
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(@"File {0} not found", args[0]);
            }
            catch (IOException e)
            {
                Console.WriteLine(@"Error reading file {0}", args[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine(@"Error : {0}", e);
            }
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

        public static List<string> biGrams(string text)
        {
            List<string> biGrams = new List<string>();
            string saveLast = "";
            StringBuilder newWordSB = new StringBuilder();

            //check first char outside loop
            if (text != "" && char.IsLetterOrDigit(text[0]))
            {
                newWordSB.Append(text[0]);
            }

            //generate biGrams
            for (int i = 1; i < text.Length - 1; i++)
            {
                char before = text[i - 1];
                char after = text[i + 1];

                if (char.IsLetterOrDigit(text[i])
                        ||
                        //keep all punctuation that is surrounded by letters or numbers on both sides.
                        (text[i] != ' '
                        && (char.IsSeparator(text[i]) || char.IsPunctuation(text[i]))
                        && (char.IsLetterOrDigit(before) && char.IsLetterOrDigit(after))
                        )
                    )
                {
                    newWordSB.Append(text[i]);
                }
                else
                {
                    if (newWordSB.Length > 0)
                    {
                        var newWord = newWordSB.ToString().ToLower();
                        newWordSB.Clear();

                        if (saveLast.Length > 0)
                        {
                            biGrams.Add(saveLast + " " + newWord);
                        }

                        saveLast = newWord;
                    }
                }
            }
            return biGrams;
        }
    }

}
