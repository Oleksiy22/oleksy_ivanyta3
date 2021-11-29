using System;
using System.Collections.Generic;

namespace LR6
{
    
    class Program
    {
        static void Main(string[] args)
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

            bool temp = true;
            while (temp)
            {
                Console.WriteLine("1-add vzvod\n2-add soldat\n3-print all\n4-delete vzvod\n5-delete soldate\n6-RUSH\n7-out of stroy\n");
                int choose = Convert.ToInt32(Console.ReadLine());

                if (choose == 1)
                {
                    Console.WriteLine("Enter name of vzvod");
                    string name = Console.ReadLine();
                    Component vzvod3 = new Composite(name);
                    rota.Add(vzvod3);
                }
                else if (choose == 2)
                {
                    Console.WriteLine("Enter name of soldat");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter name of vzvod for adding\n");
                    string namevz = Console.ReadLine();
                    Component vzvod3 = new Leaf(name);
                    rota.AddSold(namevz, vzvod3);
                }
                else if (choose == 3)
                {
                    rota.Print();
                }
                else if (choose == 4)
                {
                    Console.WriteLine("Enter name of vzvod");
                    string name = Console.ReadLine();
                    rota.Remove(name);
                }
                else if (choose == 5)
                {
                    Console.WriteLine("Enter name of vzvod");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter name of soldate");
                    string name2 = Console.ReadLine();
                    rota.RemoveSold(name, name2);
                }
                else if (choose == 6)
                {
                    soldat1.Add(soldat2);
                }
                else if (choose == 7)
                {
                    Console.WriteLine("Enter name of soldate");
                    string name2 = Console.ReadLine();
                    rota.JeftStroi(name2);
                }
                else
                {
                    temp = false;
                    
                }
            }
            
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

        public string GetName()
        {
            return name;
        }
        public virtual void Add(Component component) { }

        public virtual void Remove(string str) { }
        public virtual void RemoveSold(string vz, string sol) { }

        public virtual void Rush() { }
        public virtual void JeftStroi(string name) { }
        public virtual void AddSold(string vz, Component component) { }

        public virtual void Print()
        {
            Console.WriteLine(name);
        }
    }
    class Composite : Component
    {
        private List<Component> components = new List<Component>();

        public Composite(string name)
            : base(name)
        {
        }

        public override void Add(Component component)
        {
            components.Add(component);
        }

        public override void Remove(string str)
        {
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i].GetName() == str)
                {
                    components.Remove(components[i]);
                }
            }
        }
        public override void RemoveSold(string vz, string sol)
        {
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i].GetName() == vz)
                {
                    components[i].Remove(sol);
                }
            }
        }
        public override void Rush()
        {
            Console.Write(name);
            Console.WriteLine(" кроком руш");
            for (int i = 0; i < components.Count; i++)
            {
                components[i].Rush();
            }
        }
        public override void JeftStroi(string name)
        {
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i].GetName() == name && components[i].ToString() == "LR6.Leaf")
                {
                    Console.WriteLine("Soldate " + components[i].GetName() + " has left the steoi");
                }
                else
                {
                    components[i].JeftStroi(name);
                }
            }
        }

        public override void AddSold(string vz, Component comp)
        {
            for (int i = 0; i < components.Count; i++)
            {
                if(components[i].GetName() == vz)
                {
                    components[i].Add(comp);
                }
            }
        }

        public override void Print()
        {
            Console.WriteLine(name);
            Console.WriteLine("Вміщає1:");
            for (int i = 0; i < components.Count; i++)
            {
                components[i].Print();
            }
        }
    }

    class Leaf : Component
    {
        public override void JeftStroi(string name)
        { 
            if(this.name == name)
            {
                Console.WriteLine("Soldate " + this.name + " has left the steoi");
            }
        }
            public Leaf(string name)
                : base(name)
        { }
    }
}
