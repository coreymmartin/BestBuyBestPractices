using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BestBuyBestPractices
{
    public class Schedule
    {
        public Schedule()
        {
            Console.WriteLine("generating database management options");
            for (int i = 0; i <= 3; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }

        }

        public void DisplayMenu(string menu)
        {
            // display menus and options
            // ask for data
            // 1: main
            //      ask for data
            //      1: view/edit products
            //          1: view (single/all)
            //              ask for data
            //              1: single
            //                  ask for data
            //              2: all
            //          2: edit (add/delete)
            //              ask for data
            //          0: return/exit
            //                confirm (yes/no)
            //                  ask for data
            //                    return
            //                    exit
            //      2: view/edit departments
            //          1: view (single/all)
            //              ask for data
            //              1: single
            //                  ask for data
            //              2: all
            //          2: edit (add/delete)
            //              ask for data
            //          0: return/exit
            //                confirm (yes/no)
            //                  ask for data
            //                    return
            //                    exit
            //      0: return/exit
            //            confirm (yes/no)
            //              ask for data
            //                return
            //                exit
            // 0: exit
            //      confirm (yes/no)
            //        ask for data
            //          return
            //          exit
            switch (menu)
            {
                case "main":
                    break;
                case "confirm":
                    break;
                case "view":
                    break;
                case "edit":
                    break;
                default:
                    Console.WriteLine("whoops");
                    break;
            }

        }


    }
}
