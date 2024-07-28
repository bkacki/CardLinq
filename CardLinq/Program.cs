using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace CardLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck()
                .Shuffle()
                .Take(16);

            var grouped =
                from card in deck
                group card by card.Suit into suitGroup
                orderby suitGroup.Key descending
                select suitGroup;

            foreach(var group in grouped)
            {
                var sorted = group.OrderBy(x => x.Value);
                Console.WriteLine(group.Key);
                Console.WriteLine(String.Join(", ", group));
                Console.WriteLine(String.Join(", ", sorted));
            }

            Console.WriteLine();

            foreach(var group in grouped)
            {
                Console.WriteLine($@"Grupa: {group.Key}
Liczba elementów: {group.Count()}
Minimum: {group.Min()}
Maksimum: {group.Max()}
Elementy: {String.Join(", ", group.OrderBy(x => x.Value))}");
                Console.WriteLine();
            }
        }
    }
}
