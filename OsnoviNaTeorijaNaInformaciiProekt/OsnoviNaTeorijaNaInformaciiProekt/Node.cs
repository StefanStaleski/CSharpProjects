namespace OsnoviNaTeorijaNaInformaciiProekt
{
    public class Node
    {
        public string Simbol { get; set; }
        public double Verojatnost { get; set; }
        public string Kod { get; set; }
        public Node Levo { get; set; }
        public Node Desno { get; set; }
    }
}
