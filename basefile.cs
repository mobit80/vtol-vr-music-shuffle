using System;
using randomizer;

namespace data
{
   public class FileModifier
    {
       public void randomizer()
        {   
            int test;
            String finalSong = String.Empty;
            List<String> songs = getFiles();
            List<String> randomTags = getPrePends(songs.Count);
           // System.IO.File.Move(songs[1], @"F:\SteamLibrary\steamapps\common\VTOL VR\RadioMusic\01A Horse with No Name 2001 Remaster.mp3"); //old, new
           
            for (int i = 0; i < songs.Count; i++)
            {
                String filename = songs[i];
                List<String> nameParts = filename.Split("\\").ToList();
                String songName = nameParts[6];
                Char[] nameStart = songName.ToCharArray();
                String numbercheck = (nameStart[0] + nameStart[1]).ToString();

                if (int.TryParse(numbercheck, out test))
                {
                    if (test != 99) // 99 luftballoons edgecase
                    {
                        songName = removeFirstTwoDigits(songName);
                    }
                }

                songName = (randomTags[i] + nameParts[6]);
                nameParts[6] = songName;
                finalSong = String.Join("\\", nameParts);
            
                System.IO.File.Move(songs[i], finalSong);
            }
            foreach (string tag in randomTags)
            {Console.WriteLine(tag);}
        }

        protected List<String> getFiles()
        {
            List<String> existingSongs = new List<String>();
            existingSongs = System.IO.Directory.GetFiles(@"F:\SteamLibrary\steamapps\common\VTOL VR\RadioMusic").ToList();
            return existingSongs;
        }

        protected List<String> getPrePends(int size)
        {
            List<String> randomTags = new List<string>();
            for (int i = 0; i < size; i++)
            {
                if (i < 10)
                {
                    String prePend = "0";
                    String number = i.ToString();
                    number = prePend + number;
                    randomTags.Add(number);
                }
                else
                {
                    String number = i.ToString();
                    randomTags.Add(number);
                }
            }

            randomTags = shuffle(randomTags);

            return randomTags;
        }

        protected String removeFirstTwoDigits(String shortenMe)
        {
            char[] characters = shortenMe.ToCharArray();
            List<String> returnedNameParts = new List<string>();
            String returnedName = string.Empty;

            for (int letter = 0; letter < shortenMe.Length; letter++)
            {
                if (letter > 1)
                {
                    returnedNameParts.Add(characters[letter].ToString());
                }
            }

            returnedName = String.Join("", returnedNameParts);
            return returnedName;
        }
        private List<String> shuffle (List<String> strings)
        {
            int size = strings.Count;
            while (size > 1)
            {
                size =  size - 1;
                int randomWithinConstraint = rng.Next(size + 1);
                String swap = strings[randomWithinConstraint];
                strings[randomWithinConstraint] = strings[size];
                strings[size] = swap;
            }

            return strings;
        }

        private static Random rng = new Random();
    
    }   
}