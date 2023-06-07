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

            var customer = new Dictionary<int, int>();
            decimal totalCapacity = 0;
            decimal totalCost = 0;



            for (int i = 0; i < totalCustomer; i++)
            {
                decimal minPriceForcustomer = 0;
                decimal tempPriceForcustomer = 0;
                decimal bestPriceForCustomer = 0;
                int numberOfWarehouse = 0;
                for (int j = 0; j < totalWarehouse; j++)
                {

                    if (customers[i, j + 1] >= cost[j + 1])
                    {

                        minPriceForcustomer = customers[i, j + 1];

                        if (tempPriceForcustomer > minPriceForcustomer)
                        {
                            bestPriceForCustomer = minPriceForcustomer;
                            numberOfWarehouse = j;
                        }
                        if (bestPriceForCustomer == 0)
                        {
                            bestPriceForCustomer = minPriceForcustomer;
                            numberOfWarehouse = j;
                        }
                        tempPriceForcustomer = minPriceForcustomer;


                    }
                }
                capacity[numberOfWarehouse + 1] = capacity[numberOfWarehouse + 1] - customers[i, 0];

            }

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
