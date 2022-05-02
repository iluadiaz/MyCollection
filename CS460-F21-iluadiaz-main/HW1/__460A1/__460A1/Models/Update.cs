namespace __460A1.Models
{
    public class Update
    {
        public string rearCogSize { get; set; }

        public string frontChainSize { get; set; }

        public int wheelCirc { get; set; }

        public int pedalCadence { get; set; }

        public int row { get; set; }
        public int column { get; set; }

        public int[,] theTable = new int[201, 201];

    }
}