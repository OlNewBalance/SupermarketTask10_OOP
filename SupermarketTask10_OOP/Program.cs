using System;
using System.Collections.Generic;

namespace Task10
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        public static List<Goods> MarketStorage = new List<Goods>();
        public static Queue<Consumer> Queue = new Queue<Consumer>();
        public static double UnivermagBudgetRubles = 0;
        public static double UnivermagProfitRubles = 0;

        public static void Main()
        {
            Console.Clear();
            Console.WriteLine("Чтобы начать, нажмите ENTER...");
            string input = Console.ReadLine();
            while (input == "")
            {
                Console.Clear();
                Console.WriteLine("\nМеню.");
                Console.WriteLine("\n+ 1. Начать.");
                Console.WriteLine("\n+ 2. Выход.");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        Settings();
                        break;
                    case ConsoleKey.D2:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }
            }
        }

        private static void Settings()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nНастройки.");
                Console.WriteLine("\nСложность:.");
                Console.WriteLine("\n+ 1. Коммунизм (бесконечное число товаров, потребности покупателей обычные).");
                Console.WriteLine("\n+ 2. Социализм (уровень дефицита маленький, потребности покупателей обычные).");
                Console.WriteLine(
                    "\n+ 3. Уверенным путем (уровень дефицита средний, потребности покупателей высокие)...");
                Console.WriteLine(
                    "\n+ 4. Надо только подождать (уровень дефицита высокий, потребности покупателей высокие)...");

                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        UnivermagBudgetRubles += 10000;
                        var creationRules = new Dictionary<Func<Goods>, int>
                        {
                            { () => new Electronic(), 100 },
                            { () => new Fruits(), 100 },
                            { () => new Clothes(), 100 },
                            { () => new Alcohol(), 100 },
                            { () => new Meat(), 100 },
                            { () => new Vegetables(), 100 },
                        };

                        MarketStorage = GoodsRenderer.RenderGoods(creationRules);
                        Queue = CustomerService.CreateConsumerQueue(customerCount: 35);
                        Univermag();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.D3:
                    case ConsoleKey.D4:
                        Console.WriteLine("В разработке!");
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Неверный выбор!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void Univermag()
        {
            while (true && Queue.Count > 0)
            {
                Console.Clear();
                Console.WriteLine(
                    "\n//////////////////////////////////////////////////////////////////////////////////////////" +
                    "//////////////////////////////////////////////////////////////////////////////////////////");
                Console.WriteLine("X Товаров на складе:");
                Console.WriteLine($"Товаров на складе: {MarketStorage.Count}");
                Console.WriteLine($"Бюджет: {UnivermagBudgetRubles} руб.");
                Console.WriteLine($"Прибыль: {UnivermagProfitRubles} руб.");
                Console.WriteLine($"Осталось покупателей: {Queue.Count}");
                Console.WriteLine("Посетитель подошёл! Продолжить?");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine(
                        "//////////////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////////////////////////////////////////");
                    Consumer currentConsumer = Queue.Dequeue(); // Убираем из очереди!
                    Console.WriteLine($"Посетитель #{Queue.Count + 1}.");
                    Console.WriteLine($"Деньги: {currentConsumer.Rubles} руб.");
                    Console.WriteLine("Корзина:");
                    var basket = currentConsumer.GetBasket();

                    foreach (var item in basket)
                    {
                        Console.WriteLine($"- {item.Key}: {(item.Value ? "V" : "X")}");
                    }

                    if (basket.Values.Any(v => v))
                    {
                        if (basket["Vegetables"] != false)
                        {
                            var vegetables = MarketStorage.FirstOrDefault(g => g is Vegetables);
                            if (vegetables != null)
                            {
                                double price = 0;
                                price = vegetables.Price;
                                if (currentConsumer.Rubles >= vegetables.Price)
                                {
                                    currentConsumer.Rubles -= price;
                                    UnivermagProfitRubles += price;
                                    Console.WriteLine($"Прибыль: + {price} рублей.");
                                    currentConsumer.Bag.Add(vegetables);
                                    MarketStorage.Remove(vegetables);
                                    Console.WriteLine(
                                        $"Продажа прошла успешно! Товаров на складе {MarketStorage.Count}");
                                }
                                else
                                {
                                    currentConsumer.SetDesire("Vegetables", false);
                                }
                            }
                        }

                        if (basket["Meat"] != false)
                        {
                            var meats = MarketStorage.FirstOrDefault(m => m is Meat);
                            if (meats != null)
                            {
                                double price = 0;
                                price = meats.Price;
                                if (currentConsumer.Rubles >= meats.Price)
                                {
                                    currentConsumer.Rubles -= price;
                                    UnivermagProfitRubles += price;
                                    Console.WriteLine($"Прибыль: + {price} рублей.");
                                    currentConsumer.Bag.Add(meats);
                                    MarketStorage.Remove(meats);
                                    Console.WriteLine("54545545454");
                                    Console.WriteLine(
                                        $"Продажа прошла успешно! Товаров на складе {MarketStorage.Count}");
                                }
                                else
                                {
                                    currentConsumer.SetDesire("Meat", false);
                                }
                            }
                        }

                        if (basket["Alcohol"] != false)
                        {
                            var alcohols = MarketStorage.FirstOrDefault(m => m is Alcohol);
                            if (alcohols != null)
                            {
                                double price = 0;
                                price = alcohols.Price;
                                if (currentConsumer.Rubles >= alcohols.Price)
                                {
                                    currentConsumer.Rubles -= price;
                                    UnivermagProfitRubles += price;
                                    Console.WriteLine($"Прибыль: + {price} рублей.");
                                    currentConsumer.Bag.Add(alcohols);
                                    MarketStorage.Remove(alcohols);
                                    Console.WriteLine(
                                        $"Продажа прошла успешно! Товаров на складе {MarketStorage.Count}");
                                }
                                else
                                {
                                    currentConsumer.SetDesire("Alcohol", false);
                                }
                            }
                        }

                        if (basket["Fruits"] != false)
                        {
                            var fruits = MarketStorage.FirstOrDefault(m => m is Fruits);
                            if (fruits != null)
                            {
                                double price = 0;
                                price = fruits.Price;
                                if (currentConsumer.Rubles >= fruits.Price)
                                {
                                    currentConsumer.Rubles -= price;
                                    UnivermagProfitRubles += price;
                                    Console.WriteLine($"Прибыль: + {price} рублей.");
                                    currentConsumer.Bag.Add(fruits);
                                    MarketStorage.Remove(fruits);
                                    Console.WriteLine(
                                        $"Продажа прошла успешно! Товаров на складе {MarketStorage.Count}");
                                }
                                else
                                {
                                    currentConsumer.SetDesire("Fruits", false);
                                }
                            }
                        }

                        if (basket["Electronic"] != false)
                        {
                            var electronics = MarketStorage.FirstOrDefault(m => m is Electronic);
                            if (electronics != null)
                            {
                                double price = 0;
                                price = electronics.Price;
                                if (currentConsumer.Rubles >= electronics.Price)
                                {
                                    currentConsumer.Rubles -= price;
                                    UnivermagProfitRubles += price;
                                    Console.WriteLine($"Прибыль: + {price} рублей.");
                                    currentConsumer.Bag.Add(electronics);
                                    MarketStorage.Remove(electronics);
                                    Console.WriteLine(
                                        $"Продажа прошла успешно! Товаров на складе {MarketStorage.Count}");
                                }
                                else
                                {
                                    currentConsumer.SetDesire("Electronic", false);
                                }
                            }
                        }

                        if (basket["Clothes"] != false)
                        {
                            var clothes = MarketStorage.FirstOrDefault(m => m is Clothes);
                            if (clothes != null)
                            {
                                double price = 0;
                                price = clothes.Price;
                                if (currentConsumer.Rubles >= clothes.Price)
                                {
                                    currentConsumer.Rubles -= price;
                                    UnivermagProfitRubles += price;
                                    Console.WriteLine($"Прибыль: + {price} рублей.");
                                    currentConsumer.Bag.Add(clothes);
                                    MarketStorage.Remove(clothes);
                                    Console.WriteLine(
                                        $"Продажа прошла успешно! Товаров на складе {MarketStorage.Count}");
                                }
                                else
                                {
                                    currentConsumer.SetDesire("Clothes", false);
                                }
                            }
                        }
                        else if (basket["Clothes"] == false && basket["Electronic"] == false &&
                                 basket["Fruits"] == false
                                 && basket["Alcohol"] == false && basket["Meat"] == false &&
                                 basket["Vegetables"] == false)
                        {
                            Console.WriteLine(
                                $"Какой-то доблоеб пришел, ниче не хочет, ниче не взял... Стоит... Смотрит... " +
                                $"Молчит челик...");
                        }
                        else if (currentConsumer.Rubles <= 0)
                        {
                            Console.WriteLine($"А челик то генииииииййй, без деняк пришел, молодец, сейчас домой " +
                                              $"пойдет...");
                            continue;
                        }
                    }
                    Console.WriteLine("Покупатель обслужен! Нажмите любую клавишу...");
                    Console.ReadKey();
                }
            }
            Console.WriteLine("Все покупатели на сегодня обработаны!");
            if (UnivermagProfitRubles > 0)
            {
                Console.Clear();
                UnivermagBudgetRubles += UnivermagProfitRubles;
                UnivermagProfitRubles -= UnivermagProfitRubles;
                Console.WriteLine($"Бюджет универмага + прибыль за день: {UnivermagBudgetRubles}");
                Console.WriteLine("Чтобы выйти в меню, нажмите любую кнопку!");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Main();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("К сожалению... Прибыль нулевая! Партия нефритовый стержень, отправлять вас в" +
                                  "грязь уйгур санаторий! УДАР!");
                Environment.Exit(0);
            }
            
        }
    }
}
