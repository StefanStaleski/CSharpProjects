using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsnoviNaTeorijaNaInformaciiProekt
{
    public class ShenonFanoElias
    {
        public string Simbol { get; set; }
        public double Px { get; set; }
        public double Fx { get; set; }
        public double F1x { get; set; }
        public int KodnaDolzina { get; set; }
        public string F1xBinarno { get; set; }
        public string FinalenKod { get; set; }

        public static void KodirajShenonFanoElias(List<Node> nodes, int brojNaSimboli)
        {
            List<ShenonFanoElias> vrednosti = new List<ShenonFanoElias>();

            foreach(var node in nodes)
            {
                vrednosti.Add(new ShenonFanoElias
                {
                    Simbol = node.Simbol,
                    Px = node.Verojatnost
                });
            };
            var prvSimbol = vrednosti.FirstOrDefault();
            prvSimbol.Fx = 0;
            prvSimbol.F1x = prvSimbol.Fx + prvSimbol.Px / 2;
            prvSimbol.KodnaDolzina = Convert.ToInt32(Math.Round((-Math.Log2(prvSimbol.Px)) + 1));

            int najgolemaKodnaDolzina = 0;

            for (int i=1; i<brojNaSimboli; i++)
            {
                vrednosti[i].Fx = vrednosti[i - 1].Px + vrednosti[i - 1].Fx;
                vrednosti[i].F1x = vrednosti[i].Fx + vrednosti[i].Px / 2;
                vrednosti[i].KodnaDolzina = Convert.ToInt32(Math.Round((-Math.Log2(vrednosti[i].Px)) + 1));
                if (vrednosti[i].KodnaDolzina >= najgolemaKodnaDolzina)
                {
                    najgolemaKodnaDolzina = vrednosti[i].KodnaDolzina;
                }
            }

            foreach(var node in vrednosti)
            {
                double fb = node.F1x;
                node.F1xBinarno = "0,";

                for(int i=0; i<=najgolemaKodnaDolzina; i++)
                {
                    fb *= 2;
                    node.F1xBinarno += $"{Math.Truncate(fb)}";
                    if(fb >= 1)
                    {
                        fb -= 1;
                    }
                }

                node.FinalenKod = node.F1xBinarno.Substring(2, node.KodnaDolzina);
                Console.WriteLine($"Za simbolot '{node.Simbol}', kodot e {node.FinalenKod}.");
            }
        }
    }
}
