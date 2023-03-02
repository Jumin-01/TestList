using System.Collections.Generic;
using System.Text;

namespace Test
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Dictionary<string, dynamic> dir = new Dictionary<string, dynamic>(); 
            string selectedList = null;
            StringBuilder help = new StringBuilder();
            help.AppendLine("Ось список доступних команд:");
            help.AppendLine("Створити новий лист - AddList тип_даних назва");
            help.AppendLine("Видалити лист - DelList назва");
            help.AppendLine("Показати наявнi листи - PrintList");
            help.AppendLine("Обрати лист - SelList назва");
            help.AppendLine("вивести лист на консоль - Print");
            help.AppendLine("Довжина листа - Length");
            help.AppendLine("додати елемент в кiнець - Add значення");
            help.AppendLine("додати елемент по iндексу - Insert значення iндекс");
            help.AppendLine("видалити  елемент по iндексу  - RemoveAt iндекс");
            help.AppendLine("видалити останнiй елемент - Remove");
            help.AppendLine("видалити всi елементи - Clear");



            Console.WriteLine(" Список команд - Help");

            while (true)
            {
                //try
                //{
                    string str = Console.ReadLine();
                    string[] x = str.Split(' ');
                    if (dir.Count == 1)
                    {
                        selectedList = Convert.ToString(dir.Keys.First());
                    }
                    if (x[0].ToLower() == "help")
                    {
                        Console.WriteLine(help);
                    }
                    else if (x[0].ToLower() == "addlist")
                    {
                        if (x[1].ToLower() == "int")
                        {
                            List<int> newList = new List<int>();
                            dir.Add(x[2], newList);
                            Console.WriteLine($"Створено лиcт {x[2]} ");
                        }
                        
                        else if (x[1].ToLower() == "string")
                        {
                            List<string> newList = new List<string>();
                            dir.Add(x[2], newList);
                        }
                        else if (x[1].ToLower() == "double")
                        {
                            List<double> newList = new List<double>();
                            dir.Add(x[2], newList);
                        }
                        else if (x[1].ToLower() == "bool")
                        {
                            List<bool> newList = new List<bool>();
                            dir.Add(x[2], newList);
                        }else Console.WriteLine("Виникла помилка, лист не створено");
                    }
                    else if (x[0].ToLower() == "dellist")
                    {
                        if (dir.TryGetValue(x[1], out dynamic list))
                        {
                            dir.Remove(x[1]);
                            Console.WriteLine($"Видалено лиcт {x[1]}");
                        }
                        else Console.WriteLine($"Лиcта {x[1]} не iснує");


                    }
                    else if (x[0].ToLower() == "sellist")
                    {
                        if (dir.ContainsKey(x[1]))
                        {
                            selectedList = x[1];
                            Console.WriteLine($"Обраний лиcт {selectedList}");
                        }
                        else Console.WriteLine($"Такого листа не iснує");

                    }
                    else if (x[0].ToLower() == "printlist")
                    {
                        foreach (var item in dir)
                        {
                            Console.WriteLine($"Назва: {item.Key}; Тип даних: {item.Value}");
                        }
                    }
                    else if (x[0].ToLower() == "add")
                    {
                        if (dir.TryGetValue(selectedList, out dynamic list2) && list2 != null)
                        {
                            Console.WriteLine(Type.GetTypeCode(list2.GetType().GetGenericArguments()[0]));
                            //try
                            //{
                                if (Type.GetTypeCode(list2.GetType().GetGenericArguments()[0])== TypeCode.Int32)
                                {
                                    list2.Add(Convert.ToInt32(x[1]));
                                Console.WriteLine($"Додано значення {x[1]} до лиcта {selectedList}");
                                }
                                else if (Type.GetTypeCode(list2.GetType().GetGenericArguments()[0]) == TypeCode.Double)
                                {
                                    list2.Add(Convert.ToDouble(x[1]));
                                }
                                else if (Type.GetTypeCode(list2.GetType().GetGenericArguments()[0]) == TypeCode.String)
                                {
                                    list2.Add(Convert.ToString(x[1]));
                                }
                                else if (Type.GetTypeCode(list2.GetType().GetGenericArguments()[0]) == TypeCode.Boolean)
                                {
                                    list2.Add(Convert.ToBoolean(x[1]));
                                }
                            //}
                            //catch (Exception)
                            //{
                            //    Console.WriteLine("Введено не вiрний формат");
                            //}
                        }
                    }
                    else if (x[0].ToLower() == "removeat")
                    {
                        if (dir.TryGetValue(selectedList, out dynamic list2) && list2 != null)
                        {
                            try
                            {
                                list2.RemoveAt(Convert.ToInt32(x[1]));
                            }
                            catch (Exception)
                            {

                                Console.WriteLine("Неможливо видалити значення");
                            }
                        }
                    }
                    else if (x[0].ToLower() == "remove")
                    {
                        if (dir.TryGetValue(selectedList, out dynamic list2) && list2 != null)
                        {
                            list2.RemoveAt(list2.Count - 1);
                            Console.WriteLine("Видалено останне значення");
                        }
                    }
                    else if (x[0].ToLower() == "print")
                    {
                        if (dir.TryGetValue(selectedList, out dynamic list2) && list2 != null)
                        {
                            Console.WriteLine($"Лист {selectedList}:");
                            foreach (var item in list2)
                            {
                                Console.WriteLine(item);
                            }
                        }
                    }
                    else if (x[0].ToLower() == "insert")
                    {
                        if (dir.TryGetValue(selectedList, out dynamic list2) && list2 != null)
                        {
                            try
                            {
                                list2.Insert(Convert.ToInt32(x[2]), Convert.ToInt32(x[1]));
                                Console.WriteLine($"Значення {x[1]} додано за iндексом {x[2]}");
                            }
                            catch (Exception)
                            {

                                Console.WriteLine("Неможливо додати значення");
                            }
                        }
                    }
                    else if (x[0].ToLower() == "clear")
                    {
                        if (dir.TryGetValue(selectedList, out dynamic list2) && list2 != null)
                        {
                            list2.Clear();
                            Console.WriteLine($"Лист {selectedList} очищено");
                        }
                    }
                    else if (x[0].ToLower() == "length")
                    {
                        if (dir.TryGetValue(selectedList, out dynamic list2) && list2 != null)
                        {
                            Console.WriteLine($"Довжина листа: {list2.Count}");
                        }
                    }
                    else Console.WriteLine($"Невiдома команда ");
                    Console.WriteLine();


                //}
                //catch (Exception)
                //{

                //    Console.WriteLine("Виникла помилка, спробуй ще раз");
                //}
            }
                
        }
    }
}