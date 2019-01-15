using System;
using static System.Console;

namespace DesignPatterns
{
    //Inheritense is static, composition is dynamic
    //Assume the situation where we have too much varieties of pizzas and their costs tend to change in future

    public interface Pizza
    {
        string GetDescription();
        double GetCost();
    }

    public class PlainPizza : Pizza
    {
        public double GetCost()
        {
            return 4.0;
        }

        public string GetDescription()
        {
            return "Plain dough";
        }
    }

    public abstract class ToppingDecorator:  Pizza
    {
        protected Pizza tempPizza;
        public ToppingDecorator(Pizza pizza)
        {
            tempPizza = pizza;
        }

        public double GetCost()
        {
            return tempPizza.GetCost();
        }

        public string GetDescription()
        {
            return tempPizza.GetDescription();
        }
    }

    public class ChickenPizza : ToppingDecorator
    {
        public ChickenPizza(Pizza pizza) : base(pizza)
        {
            Write("Adding dough...");
            Write("Adding Chicken chunks...");
        }

        public new double GetCost()
        {
            return tempPizza.GetCost() +  2.00;
        }

        public new string GetDescription()
        {
            return tempPizza.GetDescription() + ", Chicken";
        }
    }

    public class TomatoSauce : ToppingDecorator
    {
        public TomatoSauce(Pizza pizza) : base(pizza)
        {
            Write("Adding tomato sauce...");
        }

        public new double GetCost()
        {
            return tempPizza.GetCost() + .50;
        }

        public new string GetDescription()
        {
            return tempPizza.GetDescription() + ", tomato sauce";
        }
    }

    public class PizzaMaker
    {
        private static void Main()
        {
            Pizza basicPizza = new TomatoSauce(new ChickenPizza(new PlainPizza()));

            Write("Ingredients: ", basicPizza.GetDescription());
            Write("Price: ", basicPizza.GetCost());

            ReadKey();
        }
    }
}
