using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3lab
{
    class Program
    {
    static void Main(string[] args)
    {
        Post Post = new Post();//создаем почту
        SubNewsPaper SubNewsPaper = new SubNewsPaper("Иван", Post);//создаем подписчика на газету
        SubMagazine SubMagazine = new SubMagazine("Коля", Post);//создаем подписчика на журнал
            Post.Publish();//обновляем\проверяем издался ли журнал и\или газета
        Console.Read();
    }
}

interface IObserver
{
    void Update(Object ob);
}

interface IObservable
{
    void RegisterObserver(IObserver o);
    void RemoveObserver(IObserver o);
    void NotifyObservers();
}

    class Post : IObservable
    {
        PostInfo sInfo; // информация 

        List<IObserver> observers;
        public Post()
        {
            observers = new List<IObserver>();
            sInfo = new PostInfo();
        }
        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver o in observers)
            {
                o.Update(sInfo);
            }
        }

        public void Publish()
        {
            Console.Write("Появилась ли новая газета?(да/нет): ");
            sInfo.Newspaper = Console.ReadLine();
            Console.Write("\nПоявился ли новый журнал?(да/нет): ");
            sInfo.Magazine = Console.ReadLine();
            Console.Write("\n");
            NotifyObservers();
        }
    }

    class PostInfo
{
    public string Newspaper { get; set; }
    public string Magazine { get; set; }
}

class SubMagazine : IObserver
{
    public string Name { get; set; }

        IObservable Post;
    public SubMagazine(string name, IObservable obs)
    {
        this.Name = name;
        Post = obs;
        Post.RegisterObserver(this);
    }
    public void Update(object ob)
    {
        PostInfo sInfo = (PostInfo)ob;

        if (sInfo.Magazine=="да")
            Console.WriteLine("Подписчик на журнал {0} получил журнал;", this.Name);
        else
            Console.WriteLine("Подписчик на журнал {0} грустит - журнала нету;", this.Name);
    }
   
}

class SubNewsPaper : IObserver
{
    public string Name { get; set; }

        IObservable Post;
    public SubNewsPaper(string name, IObservable obs)
    {
        this.Name = name;
        Post = obs;
        Post.RegisterObserver(this);
    }
    public void Update(object ob)
    {
        PostInfo sInfo = (PostInfo)ob;

        if (sInfo.Newspaper=="да")
                Console.WriteLine("Подписчик на газету {0} получил газету;", this.Name);
            else
                Console.WriteLine("Подписчик на газету {0} грустит - газеты нету;", this.Name);
        }
}
}
