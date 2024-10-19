using System;

abstract class Beverage
{
    public void PrepareRecipe()
    {
        BoilWater();
        Brew();
        PourInCup();
        if (CustomerWantsCondiments())
        {
            AddCondiments();
        }
    }

    protected abstract void Brew();
    protected abstract void AddCondiments();

    private void BoilWater() => Console.WriteLine("Кипячение воды...");
    private void PourInCup() => Console.WriteLine("Наливание в чашку...");

    protected virtual bool CustomerWantsCondiments()
    {
        Console.WriteLine("Хотите ли вы добавки? (y/n): ");
        string input = Console.ReadLine()?.ToLower();
        return input == "y";
    }
}

class Tea : Beverage
{
    protected override void Brew() => Console.WriteLine("Заваривание чая...");
    protected override void AddCondiments() => Console.WriteLine("Добавление лимона...");
}

class Coffee : Beverage
{
    protected override void Brew() => Console.WriteLine("Заваривание кофе...");
    protected override void AddCondiments() => Console.WriteLine("Добавление сахара и молока...");

    protected override bool CustomerWantsCondiments()
    {
        Console.WriteLine("Хотите добавить сахар и молоко? (y/n): ");
        string input = Console.ReadLine()?.ToLower();
        while (input != "y" && input != "n")
        {
            Console.WriteLine("Некорректный ввод. Введите 'y' для да или 'n' для нет.");
            input = Console.ReadLine()?.ToLower();
        }
        return input == "y";
    }
}

class HotChocolate : Beverage
{
    protected override void Brew() => Console.WriteLine("Подогрев шоколада...");
    protected override void AddCondiments() => Console.WriteLine("Добавление маршмеллоу...");

    protected override bool CustomerWantsCondiments()
    {
        Console.WriteLine("Хотите добавить маршмеллоу? (y/n): ");
        string input = Console.ReadLine()?.ToLower();
        while (input != "y" && input != "n")
        {
            Console.WriteLine("Некорректный ввод. Введите 'y' для да или 'n' для нет.");
            input = Console.ReadLine()?.ToLower();
        }
        return input == "y";
    }
}

class Program
{
    static void Main()
    {
        Beverage tea = new Tea();
        Console.WriteLine("Приготовление чая:");
        tea.PrepareRecipe();

        Console.WriteLine();

        Beverage coffee = new Coffee();
        Console.WriteLine("Приготовление кофе:");
        coffee.PrepareRecipe();

        Console.WriteLine();

        Beverage hotChocolate = new HotChocolate();
        Console.WriteLine("Приготовление горячего шоколада:");
        hotChocolate.PrepareRecipe();
    }
}
