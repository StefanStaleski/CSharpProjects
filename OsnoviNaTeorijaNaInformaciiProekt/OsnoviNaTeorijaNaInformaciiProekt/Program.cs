using System.Globalization;

namespace OsnoviNaTeorijaNaInformaciiProekt
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("NAPOMENA: Se zema vo predvid deka se vnesuva tocen broj na simboli so soodvetni verojatnosti.");
                Console.Write("Vnesete go brojot na simboli sto ke vnesuvate[Pr. 1 ili 15 ili 25]: ");
                int brojNaSimboli = Convert.ToInt32(Console.ReadLine());

                var provider = new NumberFormatInfo();
                provider.NumberDecimalSeparator = ".";

                List<Node> vrednosti = new List<Node>();

                for (int i = 0; i < brojNaSimboli; i++)
                {
                    Console.Write("Vnesete go imeto na simbolot[Pr. 'a' ili 'a1']: ");
                    string imeNaSimbol = Console.ReadLine();
                    Console.Write($"Vnesete ja verojatnosta za simbolot '{imeNaSimbol}'[Pr. 1.5 ili 0.25]: ");
                    double verojatnostNaSimbol = Convert.ToDouble(Console.ReadLine(), provider);
                    vrednosti.Add(new Node()
                    {
                        Simbol = imeNaSimbol,
                        Verojatnost = verojatnostNaSimbol
                    });
                }

                Console.WriteLine("\nKodiranje vo Shenon-Fano-Elias:\n");
                ShenonFanoElias.KodirajShenonFanoElias(vrednosti, brojNaSimboli);
                Console.WriteLine("\nKodiranje vo Huffman:\n");
                Huffman.Kodiraj(vrednosti);
            }
            catch(FormatException ex)
            {
                Console.WriteLine($"Dobivte FormatException. Toa znaci deka nemate vneseno tocen input. Ve molam vnesete tocno toa sto se bara.\n{ex}");
            }
        }
    }
}