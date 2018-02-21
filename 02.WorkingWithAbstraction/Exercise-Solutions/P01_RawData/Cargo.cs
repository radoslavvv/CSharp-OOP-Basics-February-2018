namespace P01_RawData
{
    public class Cargo
    {
        private int cargoWeight;
        private string cargoType;

        public Cargo(int cargoWeight, string cargoType)
        {
            this.cargoWeight = cargoWeight;
            this.cargoType = cargoType;
        }

        public int CargoWeight { get => cargoWeight; set => cargoWeight = value; }
        public string CargoType { get => cargoType; set => cargoType = value; }
    }
}