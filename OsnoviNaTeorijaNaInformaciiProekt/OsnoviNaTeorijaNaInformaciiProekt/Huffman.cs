namespace OsnoviNaTeorijaNaInformaciiProekt
{
    public class Huffman
    {
        public static List<Node> KreirajHuffmanDrvo(List<Node> nodes)
        {
            while (nodes.Count > 1)
            {
                nodes = nodes.OrderBy(n => n.Verojatnost).ThenByDescending(n => n.Simbol).ToList();
                var novNode = new Node
                {
                    Simbol = nodes[0].Simbol + nodes[1].Simbol,
                    Verojatnost = nodes[0].Verojatnost + nodes[1].Verojatnost,
                    Levo = nodes[0],
                    Desno = nodes[1]
                };
                nodes.RemoveRange(0, 2);
                nodes.Add(novNode);
            }

            return nodes;
        }

        public static void GenerirajHuffmanKodovi(Node node, string code = "")
        {
            if (node.Levo == null && node.Desno == null)
            {
                node.Kod = code;
            }
            else
            {
                GenerirajHuffmanKodovi(node.Levo, code + "1");
                GenerirajHuffmanKodovi(node.Desno, code + "0");
            }
        }

        public static void Kodiraj(List<Node> nodes)
        {
            var root = KreirajHuffmanDrvo(nodes).FirstOrDefault();
            GenerirajHuffmanKodovi(root);

            var podredeniVrednosti = nodes.OrderBy(n => n.Kod.Length);

            foreach (var node in podredeniVrednosti)
            {
                Console.WriteLine($"Za simbolot '{node.Simbol}', kodot e {node.Kod}.");
            }
        }
    }
}
