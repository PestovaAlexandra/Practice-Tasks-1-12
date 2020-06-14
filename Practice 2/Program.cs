using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Practice_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            string str = "";
            string[] s = new string[3];
            string[] temp = new string[2];
            int n;                                                                                                                  //count of trains
            string nameTrain = "", departure = "", arrival = "";
            int allMin = 1440;                                                                                                      //minutes in one day
            double minTime = 1440;                                                                                                  // the minimum time for which the train arrived
            string nameTrainMin = "";                                                                                               //the name of the train which has the minimum time for an arrival
            int distance = 650;                                                                                                     //km
            int timeTrain = 0;
            double speed = 0;
            string[] t1 = new string[2];
            string[] t2 = new string[2];
            string result = "";

            Console.WriteLine("Программа \"Быстрый поезд\"");
            using (StreamReader fIn = new StreamReader("INPUT.TXT"))
            {
                try
                {
                    n = int.Parse(fIn.ReadLine());                                                                                  //считали кол-во поездов


                    for (int i = 0; i < n; i++)                                                                                     //от информации о 1-ом поезде до последнего
                    {
                        str = fIn.ReadLine();                                                                                       //Считывание очередной строки
                        nameTrain += '\"';

                        int j = 0;
                        nameTrain = "\"";
                        do                                                                                                          //Цикл для считывания имени поезда
                        {
                            j++;
                            nameTrain += str[j];
                        }
                        while (str[j] != '\"');
                        j++;
                        j++;
                        departure = "";
                        while (str[j] != ' ')                                                                                          //Цикл для считывания времени отбытия поезда
                        {
                            departure += str[j];
                            j++;
                        }
                        j++;
                        arrival = "";
                        while (j < str.Length)                                                                                        //Цикл для считывания прибытия поезда
                        {
                            arrival += str[j];
                            j++;
                        }

                        t1 = departure.Split(':');                                                                                  //Часы отправления
                        t2 = arrival.Split(':');                                                                                    //Минуты прибытия

                        if (int.Parse(t1[0]) < int.Parse(t2[0])) //
                        {
                            timeTrain = int.Parse(t1[0]) * 60 + int.Parse(t1[1]);
                            timeTrain = int.Parse(t2[0]) * 60 + int.Parse(t2[1]) - timeTrain;
                        }
                        else
                        {
                            timeTrain = int.Parse(t1[0]) * 60 + int.Parse(t1[1]);


                            timeTrain = allMin - timeTrain + int.Parse(t2[0]) * 60 + int.Parse(t2[1]);                               // in minuts
                            if (timeTrain > allMin)
                                timeTrain -= allMin;
                        }

                        if (timeTrain <= minTime)
                        {
                            minTime = timeTrain;
                            nameTrainMin = nameTrain;
                        }
                    }
                    minTime = (double)minTime / 60;
                    if (minTime != 0)
                        speed = (double)distance / minTime;
                    speed = Math.Round(speed);
                    result = "The fastest train is " + nameTrainMin + "." + "\n" + "Its speed is " + speed + " km/h, approximately.";
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный тип входных данных");
                }
            }
            using (StreamWriter fOut = new StreamWriter("OUTPUT.TXT"))
            {

                fOut.WriteLine(result);
            }
            Console.WriteLine("Результат работы программы записан в файле OUTPUT.txt");
            Console.ReadKey();
        }
    }
}
