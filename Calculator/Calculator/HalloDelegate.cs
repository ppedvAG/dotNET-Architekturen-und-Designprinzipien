using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    delegate void EinfacherDelegate();
    delegate void DelegateMitParameter(string txt);
    delegate long CalcDelegate(int a, int b);

    public class HalloDelegate
    {
        public HalloDelegate()
        {
            EinfacherDelegate meinDele = EinfacheMethode;
            Action meineAction = EinfacheMethode;
            Action meineActionAno = delegate () { Console.WriteLine("Hallo"); };
            Action meineActionAno2 = () => { Console.WriteLine("Hallo"); };
            Action meineActionAno3 = () => Console.WriteLine("Hallo");

            DelegateMitParameter deleMirPara = MethodeMitPara;
            Action<string> actionMitPara = MethodeMitPara;
            Action<string> actionMitParaAno = (string txt) => { Console.WriteLine(txt); };
            Action<string> actionMitParaAno2 = (txt) => Console.WriteLine(txt);
            Action<string> actionMitParaAno3 = x => Console.WriteLine(x);

            CalcDelegate calcDele = Sum;
            Func<int, int, long> calcDeleFunc = Sum;
            Func<int, int, long> calcDeleAno = (x, y) => { return x * y; };
            Func<int, int, long> calcDeleAno2 = (x, y) => x * y;

            List<string> texte = new List<string>();
            texte.Where(Filter);
            texte.Where(x => x.StartsWith("b"));
        }

        private bool Filter(string arg)
        {
            if (arg.StartsWith("b"))
                return true;
            else
                return false;
        }

        private long Minus(int a, int b)
        {
            return a - b;
        }

        private long Sum(int a, int b)
        {
            return a + b;
        }

        public void EinfacheMethode()
        {
            Console.WriteLine("Hallo");
        }

        public void MethodeMitPara(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
