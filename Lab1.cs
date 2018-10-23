using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Машина 1:");
            // содаем объект директора
            Director Director = new Director();
            // создаем билдер для первого вида машины
            CarBuilder builder = new FirstCarBuilder();
            // создаем машину
            Car FirstCar = Director.Build(builder);
            Console.WriteLine(FirstCar.ToString());
            Console.WriteLine("Машина 2:");
            // создаем билдер для второго вида машины
            builder = new SecondCarBuilder();
            Car SecondCar = Director.Build(builder);
            Console.WriteLine(SecondCar.ToString());
            Console.WriteLine("Машина 3:");
            // создаем билдер для третьего вида машины
            builder = new ThirdCarBuilder();
            Car ThirdCar = Director.Build(builder);
            Console.WriteLine(ThirdCar.ToString());

            Console.Read();
        }
    }
    // абстрактный класс строителя
    abstract class CarBuilder
    {
        public Car Car { get; private set; }
        public void CreateCar()
        {
            Car = new Car();
        }
        public abstract void SetColor();
        public abstract void SetBody();
        public abstract void SetSalon();
        public abstract void SetWheel();
        public abstract void SetConditioner();
    }
    // директор
    class Director
    {
        public Car Build(CarBuilder CarBuilder)
        {
            CarBuilder.CreateCar();
            CarBuilder.SetColor();
            CarBuilder.SetBody();
            CarBuilder.SetSalon();
            CarBuilder.SetWheel();
            CarBuilder.SetConditioner();
            return CarBuilder.Car;
        }
    }
    // строитель для первого вида машины
    class FirstCarBuilder : CarBuilder
    {
        public override void SetColor()
        {
            this.Car.Color = new Color { Name = "Цвет красный" };
        }

        public override void SetBody()
        {
            this.Car.Body = new Body { Name = "Кузов Седан" };
        }

        public override void SetSalon()
        {
            this.Car.Salon = new Salon { Name = "Салон кожаный" };
        }
        public override void SetWheel()
        {
            this.Car.Wheel = new Wheel { Name = "Колеса Стальные" };
        }
        public override void SetConditioner()
        {
            this.Car.Conditioner = new Conditioner { Name = "Кондиционер есть" };
        }
    }
    // строитель для второго вида
    class SecondCarBuilder : CarBuilder
    {
        public override void SetColor()
        {
            this.Car.Color = new Color { Name = "Цвет желтый" };
        }

        public override void SetBody()
        {
            this.Car.Body = new Body { Name = "Кузов Хетчбек" };
        }

        public override void SetSalon()
        {
            this.Car.Salon = new Salon { Name = "Салон кожаный" };
        }
        public override void SetWheel()
        {
            this.Car.Wheel = new Wheel { Name = "Колесо стальные" };
        }
        public override void SetConditioner()
        {
            //не используется
        }
    }
    //третий вид
    class ThirdCarBuilder : CarBuilder
    {
        public override void SetColor()
        {
            this.Car.Color = new Color { Name = "Цвет синий" };
        }

        public override void SetBody()
        {
            this.Car.Body = new Body { Name = "Кузов Кроссовер" };
        }

        public override void SetSalon()
        {
            this.Car.Salon = new Salon { Name = "Салон кожаный" };
        }
        public override void SetWheel()
        {
            this.Car.Wheel = new Wheel { Name = "Колеса стальные" };
        }
        public override void SetConditioner()
        {
           //не используется
        }
    }
    //цвет
    class Color
    {
        // какого цвета машина
        public string Name { get; set; }
    }
    // кузов
    class Body
    {
        public string Name { get; set; }
    }
    // салон
    class Salon
    {
        public string Name { get; set; }
    }
    //колеса
    class Wheel
    {
        public string Name { get; set; }
    }
    //доп. опция - кондиционер
    class Conditioner
    {
        public string Name { get; set; }
    }
    class Car
    {
       
        public Color Color { get; set; }
       
        public Body Body { get; set; }
   
        public Salon Salon { get; set; }
        public Wheel Wheel { get; set; }
        public Conditioner Conditioner { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (Color != null)
                sb.Append(Color.Name + "\n");
            if (Wheel != null)
                sb.Append(Wheel.Name + "\n");
            if (Body != null)
                sb.Append(Body.Name + "\n");
            if (Salon != null)
                sb.Append(Salon.Name + "\n");
            if (Conditioner != null)
                sb.Append(Conditioner.Name + "\n");
            return sb.ToString();
        }
    }
}
