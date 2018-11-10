using System;
using System.Collections.Generic;
using System.Linq;


namespace _2lab
{
    class Program
    {
        static void Main(string[] args)
        {
            //создаем текст
            Component NewText = new Text("Новый Текст");
            //создаем абзацы
            Component paragraph1 = new Paragraph("Абзац1");
            Component paragraph2 = new Paragraph("Абзац2");
            //создаем предложения
            Component sentence1 = new Sentence("Предложение1");
            Component sentence2 = new Sentence("Предложение2");
            Component sentence3 = new Sentence("Предложение3");
            //создаем слова
            Component Word1 = new Word("Слово1", "Привет");
            Component Word2 = new Word("Слово2", ", ");
            Component Word3 = new Word("Слово3", "Мир");
            Component Word4 = new Word("Слово4", "! ");
            Component Word5 = new Word("Слово5", "Hello");
            Component Word6 = new Word("Слово6", "Слово");
            // добавляем  в абзац два предложения
            paragraph1.Add(sentence1);
            paragraph1.Add(sentence2);
            paragraph2.Add(sentence3);

            // добавляем в текст  абзацы
            NewText.Add(paragraph1);
            NewText.Add(paragraph2);
            //слова в предложения
            sentence1.Add(Word1);
            sentence1.Add(Word2);
            sentence1.Add(Word3);
            sentence1.Add(Word4);
            sentence2.Add(Word5);
            sentence3.Add(Word6);
            // выводим все данные
            NewText.Print();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            NewText.Print_Content();

            Console.Read();
        }
    }

    abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }

        public virtual void Add(Component component) { }


        public virtual void Remove(Component component) { }

        public virtual void Print()
        {
            Console.WriteLine(name);
        }
        public virtual void Print_Content()
        {
            Console.WriteLine(name);
        }
    }

    class Text : Component
    {
        private List<Component> components = new List<Component>();

        public Text(string name)
            : base(name)
        {
        }

        public override void Add(Component component)
        {
            components.Add(component);
        }

        public override void Remove(Component component)
        {
            components.Remove(component);
        }

        public override void Print()
        {
            Console.WriteLine("Текст " + name);
            Console.WriteLine("Параграф:");
            for (int i = 0; i < components.Count; i++)
            {
                components[i].Print();

            }
        }
        public override void Print_Content()
        {

            for (int i = 0; i < components.Count; i++)
            {
                components[i].Print_Content();

            }
        }
    }

    class Paragraph : Component
    {
        private List<Component> components = new List<Component>();

        public Paragraph(string name)
            : base(name)
        {
        }

        public override void Add(Component component)
        {
            components.Add(component);
        }

        public override void Remove(Component component)
        {
            components.Remove(component);
        }

        public override void Print()
        {
            Console.WriteLine("Параграф " + name);
            Console.WriteLine("Предложение:");
            for (int i = 0; i < components.Count; i++)
            {
                components[i].Print();
            }
        }
        public override void Print_Content()
        {

            for (int i = 0; i < components.Count; i++)
            {
                components[i].Print_Content();
            }
            Console.WriteLine();
        }

    }

    class Sentence : Component
    {
        private List<Component> components = new List<Component>();

        public Sentence(string name)
            : base(name)
        {
        }

        public override void Add(Component component)
        {
            components.Add(component);
        }

        public override void Remove(Component component)
        {
            components.Remove(component);
        }

        public override void Print()
        {
            Console.WriteLine("Предложение " + name);
            Console.WriteLine("Слова:");
            for (int i = 0; i < components.Count; i++)
            {
                components[i].Print();

            }

        }
        public override void Print_Content()
        {

            for (int i = 0; i < components.Count; i++)
            {
                components[i].Print_Content();

            }

        }
    }

    class Word : Component
    {
        protected string content;
        public Word(string name, string content)
            : base(name)
        {
            this.content = content;
        }
        public override void Print()
        {
            Console.WriteLine("Слово " + name + "  Слово:" + content);

        }
        public override void Print_Content()
        {
            Console.Write(content);
        }
    }
}

