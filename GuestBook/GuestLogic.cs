using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBook
{
    public static class GuestLogic
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to the Guest Book App");
            Console.WriteLine("*****************************");
            Console.WriteLine();
        }

        public static string GetPartyName()
        {
            Console.Write("What is your party/group name: ");
            string partyName = Console.ReadLine();

            return partyName;
        }

        public static int GetPartySize()
        {
            bool isValidNumber;
            int partySize;

            do
            {
                Console.Write("How many people are in your party: ");
                string partySizeText = Console.ReadLine();
                isValidNumber = int.TryParse(partySizeText, out partySize);
            } while (!isValidNumber);

            return partySize;
        }

        public static bool AskToContinue()
        {
            Console.Write("Are there more guests coming (yes/no): ");
            string continueLooping = Console.ReadLine();
            Console.WriteLine();

            bool output = (continueLooping.ToLower() == "yes");

            return output;
        }

        public static (List<string> guests, int total, Dictionary<string, int> familiesWithGuestsCount) GetAllGuests()
        {
            int totalGuests = 0;

            Dictionary<string, int> familiesWithNumberOfGuests = new Dictionary<string, int>();

            string continueLooping;
            string partyName;
            int partySize;

            List<string> guests = new List<string>();

            do
            {
                partyName = GetPartyName();
                guests.Add(partyName);
                partySize = GetPartySize();
                totalGuests += partySize;

                familiesWithNumberOfGuests.Add(partyName, partySize);

            } while (AskToContinue());

            return (guests, totalGuests, familiesWithNumberOfGuests);
        }

        public static void DisplayGuestList(Dictionary<string, int> familiesWithGuestsCount)
        {
            foreach (var guest in familiesWithGuestsCount)
            {
                Console.WriteLine($"{guest.Key}: {guest.Value}");
            }
            Console.WriteLine();
        }

        public static void DisplayGuestsCount(int totalGuests)
        {
            Console.WriteLine("Thank you for everyone who attended.");
            Console.WriteLine($"The total guests count for this evening was {totalGuests}");
        }
    }
}
