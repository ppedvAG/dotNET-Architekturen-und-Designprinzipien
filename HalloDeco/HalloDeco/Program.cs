using System;
using System.Text;

namespace HalloDeco
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Hello Deco!");


            var brot = new Käse(new Brot());
            Show(brot);
            var pizz = new Ananas(new Salami(new Käse(new Käse(new Pizza()))));
            Show(pizz);

        }

        private static void Show(ICompo compo)
        {
            Console.WriteLine($"{compo.Name} {compo.Preis:c}");
        }
    }

    public interface ICompo
    {
        public string Name { get; }
        public decimal Preis { get; }
    }

    public class Brot : ICompo
    {
        public string Name => "Brot";

        public decimal Preis => 2.5m;
    }

    public class Pizza : ICompo
    {
        public string Name => "Pizza";

        public decimal Preis => 5.7m;
    }


    public class Käse : Deco
    {
        public Käse(ICompo compo) : base(compo)
        { }

        public override string Name => $"{parent.Name} Käse";

        public override decimal Preis => parent.Preis + 2.2m;
    }

    public class Salami : Deco
    {
        public Salami(ICompo compo) : base(compo)
        { }

        public override string Name => $"{parent.Name} Salami";

        public override decimal Preis => parent.Preis + 3.8m;
    }

    public class Ananas : Deco
    {
        public Ananas(ICompo compo) : base(compo)
        { }

        public override string Name => $"{parent.Name} Ananas";

        public override decimal Preis => parent.Preis + -5m;
    }

    public abstract class Deco : ICompo
    {
        protected ICompo parent;
        public Deco(ICompo parent)
        {
            this.parent = parent;
        }

        public abstract string Name { get; }

        public abstract decimal Preis { get; }
    }
}
