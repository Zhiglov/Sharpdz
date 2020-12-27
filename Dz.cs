using System;
using System.Xml.Serialization;
using System.IO;

//Жиглов Г.Д. ИУ6-74Б Вариант B1
namespace ApplicationHomework
{
    // Тип вагона -- пассажирский или товарный
    public enum WagonTypeEnum
    {
        Passenger,
        Trade
    }

    // Тип Локомотива -- Тепловой или электровоз
    public enum LocoTypeEnum
    {
        thermal,
        electric
    }

    [Serializable]
    public class Wagon
    {
        public string Name { get; set; }
        public int SerialNumber { get; set; }
        public WagonTypeEnum WagonType { get; set; }
        public int Seats { get;set } 
        public int Gruz  { get;set }

        // стандартный конструктор без параметров
        public Wagon() { }

        public Wagon(string name, int serialNumber, WagonTypeEnum wagonType, int seats, int gruz)
        {
            Name = name;
            SerialNumber = serialNumber;
            WagonType = wagonType;
            Seats = seats;
            Gruz = gruz;
        }
    }

    [Serializable]
    public class Loco
    {
        public string Name { get; set; }
        public int SerialNumber { get; set; }
        public LocoTypeEnum LocoType { get; set; }

        //  конструктор без параметров
        public Loco() { }

        public Loco(string name, int serialNumber, LocoTypeEnum locoType)
        {
            Name = name;
            SerialNumber = serialNumber;
            LocoType = locoType;
        }
    }

    [Serializable]
    public class Train
    {
        public int  Number { get; set; }
        public Loco TrainLoco { get; set; }
        public Wagon[] Wagons { get; set; }

        public Train() { }

        public Train(int number, Loco trainLoco, Wagon[] wagons)
        {
		Number = number;
		TrainLoco = trainLoco;
		Wagons = wagons
        }
    }

 class Program
    {
        static void Main(string[] args)
        {
            var v1 = new Wagon("Alpha", 1, WagonTypeEnum.Passenger, 60, 0);
            var v2 = new Wagon("Beta", 2, WagonTypeEnum.Trade, 0, 10);
            Wagon[] wagons = new Wagon[] { v1, v2 };
            var loco = new Loco("Fire", 1, LocoTypeEnum.thermal);
            var train = new Train(3, loco, wagons);

            XmlSerializer formatter = new XmlSerializer(typeof(Train));

            using (FileStream fs = new FileStream("train.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, train);
            }
        }
    }
}
}