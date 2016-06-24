using System;

namespace LC_CountNumbersWithUniqueDigits
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //int count = CountNumbersWithUniqueDigits(2);
            int count = CountNumbersWithUniqueDigits_Dynamic(1);
            Console.WriteLine("10^1 = "+count);
            count = CountNumbersWithUniqueDigits_Dynamic(2);
            Console.WriteLine("10^2 = "+count);
            count = CountNumbersWithUniqueDigits_Dynamic(3);
            Console.WriteLine("10^3 = "+count);
        }

        public static int CountNumbersWithUniqueDigits_Dynamic(int n)
        {
            if(n==0)
            {
                return 1;
            }
            else
            {
                int tmp = 1;
                int multiple = 10;
                for(int i=0;i<n;i++)
                {
                    if(i==0)
                    {
                        tmp *= (multiple-1); // first digital
                    }
                    else
                    {
                        tmp*=multiple;
                    }
                    multiple--;
                }
                tmp += CountNumbersWithUniqueDigits_Dynamic(n-1);
                return tmp;

            }
        }


        public static int CountNumbersWithUniqueDigits(int n) 
        {
            int same_count = 0;
            int ret_unique_count = 0;
            double maxVal = Math.Pow(10.0,n);
        
            int range_min = 10;
            int range_max = (int)maxVal-1;
            
            if(n==1 || n==0)
            {
                ret_unique_count = 0;
            }
            else
            {
                for(int i=range_min ; i<=range_max ; i++)
                {                    
                    int[] digital10 = new int[10];
                    int num = i;
                    bool bSame = false;
                    do
                    {
                        int quotient = num/10;
                        int remainder = num%10;                        
                        num = quotient;                    
                        if(digital10[remainder] > 0)
                        {
                            // means repeat
                            same_count++;
                            bSame = true;
                            break;
                        }
                        else
                        {
                            digital10[remainder]++;
                        }
                    }
                    while(num>0);
                    
                    if(bSame)
                    {
                        Console.WriteLine(i);
                    }
                }            
            }
            ret_unique_count = range_max - same_count;
            return ret_unique_count;
        }
    }
}
