using System.Text.Json;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace Test
{
    internal class Program
    {
        
        static void Main(string[] args)
        {   
            List <int> list = new List<int>() { 58,89,56565,79797,458,78};
            StringBuilder help = new StringBuilder();
            help.AppendLine("Ось список доступних команд:");
            help.AppendLine("вивести на лист на консоль - Print");
            help.AppendLine("Довжина листа - Length");
            help.AppendLine("додати елемент в кiнець - Add значення");
            help.AppendLine("додати елемент по iндексу - Insert значення iндекс");
            help.AppendLine("видалити  елемент по iндексу  - RemoveAt iндекс");
            help.AppendLine("видалити останнiй елемент - Remove");
            help.AppendLine("видалити всi елементи - Clear");



            Console.WriteLine(" Список команд - Help");
            while (true)
            {
                string str = Console.ReadLine();
                string[] x = str.Split(' ');
                 if (x[0] == "Help")
                {
                    Console.WriteLine(help);
                }
                else if (x[0] == "Add")
                {
                    list.Add(Convert.ToInt32(x[1]));
                }
                else if (x[0] == "RemoveAt")
                {
                    list.RemoveAt(Convert.ToInt32(x[1]));
                }else if (x[0] == "Remove")
                {
                    list.RemoveAt(list.Count-1);
                }
                else if (x[0] == "Print")
                {
                    foreach (var item in list)
                    {
                        Console.WriteLine(item);
                    }
                }else if (x[0] == "Insert")
                {
                    list.Insert(Convert.ToInt32(x[2]), Convert.ToInt32(x[1]));
                }else if (x[0] == "Clear")
                {
                    list.Clear();
                }else if (x[0] == "Length")
                {
                    Console.WriteLine(list.Count) ;
                }
                Console.WriteLine();
            }
                    
                    
                
                    
                    

                 
                   

            
            
            
            
           
        }
    }
}