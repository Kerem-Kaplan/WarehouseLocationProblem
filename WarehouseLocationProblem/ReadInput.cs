using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLocationProblem
{
    public class ReadInput
    {
        readonly string wl16 = "..\\..\\..\\wl_16_1";
        readonly string wl200 = "..\\..\\..\\wl_200_2";
        readonly string wl500 = "..\\..\\..\\wl_500_3";

        public List<Decimal> ReadCapacity()
        {
            StreamReader streamReader = new(wl16);

            string line;
            line = streamReader.ReadLine();

            List<Decimal> capacity = new();


            while (line != null)
            {
                string[] lineValues = line.Split(' ');

                if (lineValues.Length == 2)
                {
                    capacity.Add(Decimal.Parse(lineValues[0]));
                }
                line = streamReader.ReadLine();

            }
            streamReader.Close();
            return capacity;
        }

        public List<Decimal> ReadCost()
        {
            StreamReader streamReader = new(wl16);
            string line;

            line = streamReader.ReadLine();

            List<Decimal> cost = new();

            while (line != null)
            {

                string[] lineValues = line.Split(' ');

                if (lineValues.Length == 2)
                {
                    cost.Add(Decimal.Parse(lineValues[1]));
                }

                line = streamReader.ReadLine();

            }

            streamReader.Close();
            return cost;
        }

        public decimal[,] ReadCustomer()
        {



            StreamReader streamReader = new(wl16);
            string line;
            string[] lineValues;
            line = streamReader.ReadLine();

            string[] total = line.Split(' ');
            string totalCustomer = total[1];    //50    200     500
            string totalWarehouse = total[0];   //16    200     500

            decimal[,] customers = new decimal[Convert.ToInt32(totalCustomer), Convert.ToInt32(totalWarehouse) + 1];

            int k = 0;

            while (line != null)
            {
                lineValues = line.Split(' ');

                if (lineValues.Length == 1)
                {
                    
                    customers[k, 0] = Decimal.Parse(lineValues[0]);

                }

                if (lineValues.Length == Convert.ToInt32(totalWarehouse))
                {
                    for (int i = k; i < Convert.ToInt32(totalCustomer); i++)
                    {
                        int n = 0;
                        for (int j = 1; j <= lineValues.Length; j++)
                        {
                            customers[i, j] = Decimal.Parse(lineValues[n]);
                            n++;
                        }
                    }
                    k++;
                }

                line = streamReader.ReadLine();

            }
            streamReader.Close();
            return customers;
        }
    }
}

