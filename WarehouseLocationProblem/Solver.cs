using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLocationProblem
{
    public class Solver
    {
        public void Solving()
        {
            ReadInput readInput = new();

            List<decimal> capacity = readInput.ReadCapacity();
            List<decimal> cost = readInput.ReadCost();
            decimal[,] customers = readInput.ReadCustomer();

            decimal totalWarehouse = capacity[0];
            decimal totalCustomer = cost[0];

            int[] warehouseOfCustomer = new int[Convert.ToInt32(cost[0])];

            decimal[] warehouseCost = new decimal[Convert.ToInt32(capacity[0])];


            for (int j = 0; j < totalCustomer; j++)
            {
                decimal minPriceForCustomer = 0;
                decimal bestPriceForCustomer = 0;
                int numberOfWarehouse = 0;
                for (int k = 0; k < capacity[0]; k++)
                {
                    if (customers[j, 0] > capacity[k + 1])
                    {
                        continue;
                    }
                    minPriceForCustomer = customers[j, k + 1];
                    if (bestPriceForCustomer == 0)
                    {
                        bestPriceForCustomer = minPriceForCustomer;
                        numberOfWarehouse = k;

                    }
                    if (minPriceForCustomer < bestPriceForCustomer)
                    {
                        bestPriceForCustomer = minPriceForCustomer;
                        numberOfWarehouse = k;
                    }
                }

                capacity[numberOfWarehouse + 1] = capacity[numberOfWarehouse + 1] - customers[j, 0];

                if (capacity[numberOfWarehouse + 1] > 0)
                {
                    warehouseOfCustomer[j] = numberOfWarehouse;
                    warehouseCost[numberOfWarehouse] += bestPriceForCustomer;
                }
                else
                {
                    capacity[numberOfWarehouse + 1] = capacity[numberOfWarehouse + 1] + customers[j, 0];
                }

            }
            decimal optimalCost = 0;
            for (int n = 0; n < warehouseCost.Length; n++)
            {
                optimalCost += warehouseCost[n];
            }
            Console.WriteLine(optimalCost);
            for (int m = 0; m < warehouseOfCustomer.Length; m++)
            {
                Console.Write(warehouseOfCustomer[m] + " ");
            }
            Console.ReadLine();



            /*decimal optimalCost = 0;
            decimal tempCost = 0;

            int[] warehouseOfCustomer = new int[Convert.ToInt32(cost[0])];

            for (int i = 0; i < totalCustomer; i++)
            {
                decimal minPriceForcustomer = 0;
                decimal bestPriceForCustomer = 0;
                int numberOfWarehouse = 0;
                for (int j = 0; j < totalWarehouse; j++)
                {
                    if (customers[i, j + 1] >= cost[j + 1])
                    {
                        if (customers[i, 0] <= capacity[j + 1])
                        {
                            minPriceForcustomer = customers[i, j + 1];
                            if (bestPriceForCustomer == 0)
                            {
                                tempCost = 0;
                                bestPriceForCustomer = minPriceForcustomer;
                                tempCost += customers[i, j + 1];
                                numberOfWarehouse = j;
                            }
                            if (minPriceForcustomer < bestPriceForCustomer)
                            {
                                tempCost = 0;
                                bestPriceForCustomer = minPriceForcustomer;
                                numberOfWarehouse = j;
                                tempCost += customers[i, j + 1];
                            }

                        }
                    }
                }
                warehouseOfCustomer[i] = numberOfWarehouse;
                capacity[numberOfWarehouse + 1] = capacity[numberOfWarehouse + 1] - customers[i, 0];
                optimalCost += tempCost;
            }

            Console.WriteLine(optimalCost + "\n");

            for (int i = 0; i < warehouseOfCustomer.Length; i++)
            {
                Console.Write(warehouseOfCustomer[i] + " ");
            }

            Console.ReadLine();*/

            /*
            decimal totalCost = 0;
            decimal tempCost = 0;
            decimal optimalCost = 0;

            int counter = 0;
            while (counter < 4)
            {
                for (int k = 0; k < capacity[0]; k++)   //16
                {
                    decimal totalCapacity = 0;
                    for (int n = 0; n < cost[0]; n++)   //50
                    {
                        if (totalCapacity <= capacity[k + 1] && customers[n, 1] <= capacity[k + 1] && customers[n, k + 2] >= cost[k + 1] && customers[n, 0] == 0)   //her depoyu müşterinin isteklerine göre kontrol etme işlemi
                        {
                            customers[n, 0] = 1;
                            totalCapacity += customers[n, 1];
                            totalCost += customers[n, k + 2];
                            if (totalCapacity > capacity[k + 1])
                            {
                                totalCapacity -= customers[n, 1];
                                totalCost -= customers[n, k + 2];
                                customers[n, 0] = 0;
                            }
                            else
                            {
                                Console.WriteLine("Müşteri sirasi:" + n + "," + "depo numarasi:" + k + " " + "Müsteri verdigi para:" + customers[n, k + 2] + " ");

                            }
                        }
                    }
                    Console.WriteLine("\n");
                    tempCost = totalCost;
                }

                if (counter == 0)
                {
                    optimalCost = tempCost;
                }

                if (tempCost <= optimalCost)
                {
                    optimalCost = tempCost;
                }
                Console.WriteLine("Optimal Cost: " + optimalCost);

                for (int m = 0; m < cost[0]; m++)
                {
                    customers[m, 0] = 0;
                }
                counter++;
            }*/
        }
    }
}
