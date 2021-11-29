using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR6
{
    class Facade
    {
        public Facade()
        {
            Component rota = new Composite("Рота");
            Component vzvod1 = new Composite("Взвод 1");
            Component vzvod2 = new Composite("Взвод 2");
            Component soldat1 = new Leaf("Петренко");
            Component soldat2 = new Leaf("Комаров");
            Component soldat3 = new Leaf("Зінченко");
            Component soldat4 = new Leaf("Іваненко");
            vzvod1.Add(soldat1);
            vzvod1.Add(soldat2);
            vzvod2.Add(soldat3);
            vzvod2.Add(soldat4);
            rota.Add(vzvod1);
            rota.Add(vzvod2);
        }
        public void AddObj(Component com, int ch1, int ch2)
        {
            //if()



        }

    }
}
