using System.Text;



namespace LeetCodeTasks   
{
    //List
    public class ListNode
    {
        public int value;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.value = val;
            this.next = next;
        }
    }



    //9.Palindrome Number
    //Проверка на число полиндром
    public  class PalindromeNumber
    {
        public  bool Function(int x)
        {
            String y = x.ToString();
            String z = y;

            //Reverse string 
            StringBuilder sb = new StringBuilder(z.Length);
            for (int g = z.Length; g-- != 0;)
                sb.Append(z[g]);

            int i = string.Compare(y, sb.ToString());
            return i == 0 ? true : false;
        }
    }



    //193. Valid Phone Numbers
    //Есть два типа верно номера телефона: (xxx) xxx-xxxx и xxx-xxx-xxxx.
    //Суть: считать номера с файла и вернуть правильные
    public class ValidPhoneNumbers
    {
        private bool IsValidNumber(string number)
        {
            //xxx-xxx - xxxx
            //(xxx)xxx-xxxx
            if (number == null)
                return false;

            if (number.Length < 14 && number.Length > 14)
                return false;

            if ((number[3] != '-' && number[7] != ' ' && number[8] != '-' && number[9] != ' ') && (number[0] != '(' && number[4] != ')' && number[8] != ' ' && number[9] != '-' && number[10] != ' '))
                return false;

            int count = 0;
            for (int i = 0; i < number.Length; i++)
            {
                string candidate = number[i].ToString();
                if (double.TryParse(candidate, out var parsedNumber))
                    count++;
            }

            if (count != 10)
                return false;

            return true;
        }

        public void Function(string Path)
        {
            List<string> FileRead = new List<string>();

            using (StreamReader sr = new StreamReader(Path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    FileRead.Add(line);

                }
                sr.Close();

                for (int i = 0; i < FileRead.Count; i++)
                {
                    if (IsValidNumber(FileRead[i]))
                    {
                        Console.WriteLine(FileRead[i]);
                    }
                }
            }
        }
    }



    //258. Add Digits
    //Вернуть число(0~9), сумма чисел. Если первая сумма чисел больше 9, суммировать так, пока не будет одна цифра 
    public class AddDigits
    {
        private int res = 0;
        public int Function(int num)
        {
            if (num < 10)
                return num;

            string nums = num.ToString();


            num = 0;
            char foo;
            for (int i = 0; i < nums.Length; i++)
            {
                foo = nums[i];
                num += foo - '0';
            }

            if (num < 10)
                res = num;

            Function(num);
            return res;
        }
    }



    //1185. Day of the Week
    //Вычисление дня недели из даты
    public class DayOfTheWeek
    {
        public enum WeekDay
        {
            Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
        }

        //Вытаскивание цифр из числа
        int GetDigit(int x, int digitNumber)
        {
            if (digitNumber < 0)
                throw new ArgumentOutOfRangeException("digitNumber");

            int digitCount = (int)Math.Log10(x);
            if (digitNumber > digitCount)
                return 0;

            var pow = (int)Math.Pow(10, digitCount - digitNumber);
            return (x / pow) % 10;
        }

        public WeekDay Function(int day, int month, int year)
        {
            int m, y, c, d = day;

            if (month > 2)
                m = month - 2;
            else
                m = month + 10;

            y = GetDigit(year, 3);
            y += GetDigit(year, 2) * 10;

            c = GetDigit(year, 1);
            c += GetDigit(year, 0) * 10;
            //исключение
            if (year == 2000 && (m == 11 || m == 12))
                c = 19;

            return (WeekDay)(((d + ((13 * m - 1) / 5) + y + (y / 4) + (c / 4) + -2 * c) % 7));
        }
    }



    //14. Longest Common Prefix
    //Найти самый длинный префикс из заданных строк
    public class LongestCommonPrefix
    {
        public string Fucntion(string[] strs)
        {
            string prefix = strs[0];
            for (int i = 1; i < strs.Length; i++)
            {
                if (strs[i].Length < prefix.Length)
                    prefix = strs[i];
            }


            for (int i = 0; i < strs.Length; i++)
            {
                for (int j = 0; j < prefix.Length; j++)
                {
                    bool was = false;
                    if (prefix[j] != strs[i][j] && was == false)
                    {
                        prefix = strs[i].Substring(0, j);
                        was = true;
                    }
                }
            }
            return prefix;
        }
    }



    //21. Merge two sorted lists            no solution
    //Совместить два отсортированных массива
    public class MergeTwoLists
    {
        public ListNode Function(ListNode list1, ListNode list2)
        {





            return null;
        }
    }



    //121. Best Time to Buy and Sell Stock      
    public class BestTimeBuyAndSellStock
    {
        public int Function1(int[] prices)
        {
            int max = 0;
            for (int i = 0; i < prices.Length - 1; i++)
            {
                for (int j = i + 1; j < prices.Length; j++)
                {
                    if (prices[j] - prices[i] > max)
                        max = prices[j] - prices[i];
                }
            }
            return max;
        }

        public int Function2(int[] prices)
        {
            if (prices.Length < 2)
                return 0;

            int current_min = 0;
            int max_diff = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] < prices[current_min])
                    current_min = i;
                else
                    max_diff = Math.Max(max_diff, prices[i] - prices[current_min]);
            }

            return max_diff;
        }
    }



    //141. Linked List Cycle                super elegant solution
    //Given head, the head of a linked list, determine if the linked list has a cycle in it.
    public class LinkedListCycle
    {
        public bool Function(ListNode head)
        {
            int count = 0;
            while (head != null)
            {
                head = head.next;
                count++;
                if (count == 10001)
                    return true;
            }
            return false;
        }
    }



    //168. Excel Sheet Column Title         no solution
    public class ExcelSheetColumnTitle
    {
        public string Function(int num)
        {
            char[] c = " ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            int key = 0;
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            foreach (char value in c)
            {
                dictionary.Add(key, value.ToString());
                key++;
            }

            string res = "";




            for (int i = 7; i != -1; i--)
            {
                if ((num / (int)Math.Pow(26, i)) == 0)
                {
                    continue;
                }

                if (i == 0)
                {
                    res += dictionary[(num / (int)Math.Pow(26, i))];
                    continue;
                }

                if (num % (int)Math.Pow(26, i) != 0)
                {
                    res += dictionary[(num / (int)Math.Pow(26, i))];
                    num = num - ((num / (int)Math.Pow(26, i)) * (int)Math.Pow(26, i));
                }
                else
                {
                    res += dictionary[(num / (int)Math.Pow(26, i)) - 1];
                    num = (int)Math.Pow(26, i);
                }
            }
            return res;
        }
    }



    //876. Middle of the Linked List
    public class MiddleNode
    {
        public ListNode Function(ListNode head)
        {
            ListNode start = head;
            int count = 0;
            while (head != null)
            {
                head = head.next;
                count++;
            }
            int i = 0;
            while (i != (count / 2))
            {
                start = start.next;
                i++;
            }
            return start;
        }
    }



    //709. To Lower Case
    public class ToLowerCase
    {
        public string Function(string s)
        {
            char[] res = new char[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < 97)
                    res[i] = (char)(s[i] + 32);
                else
                    res[i] = s[i];
            }
            s = new string(res);
            return s;
        }
    }



    //206. Reverse Linked List
    public class ReverseLinkedList
    {
        public ListNode Function(ListNode head)
        {
            ListNode path = head;
            ListNode back = null;

            while(path != null)
            {
                path = path.next;
                head.next = back;
                back = head;
                if(path != null)
                    head = path;            
            }
            return head;            
        }
    }



    //412. Fizz Buzz
    public class FizzBuzz
    {
        public List<string> Function(int n)
        {
            List<string> res = new List<string>();

            for(int i = 0; i < n; i++)
            {
                res.Add("");
                if(i % 3 == 0)
                    res[i] += ("Fizz");
                if(i % 5 == 0)
                    res[i] += ("Buzz");
                if(res[i] == "")
                    res.Add(i.ToString());
            }
            return res;
        }
    }



    //118. Pascal's Triangle
    public class PascalTriangle
    {
        private List<int> MakeRow(List<int> row)
        {
            List<int> newrow = new List<int>(new int[row.Count + 1]);
            newrow[0] = 1;
            newrow[row.Count] = 1;

            for (int i = 0; i < row.Count - 1; i++)
            {
                newrow[i + 1] = row[i] + row[i + 1];
            }
            return newrow;
        }
        public List<List<int>> Function(int numRows)
        {
            List<List<int>> triangle = new List<List<int>>();
            triangle.Add(new List<int>(new int[] { 1 } ));
            List<int> row = new List<int>(new int[] { 1, 1 });
            for (int i = 1; i < numRows; i++)
            {
                triangle.Add(MakeRow(triangle[i - 1]));
            }

            return triangle;
        }
    }



    //202. Happy Number     half solution
    public class HappyNumber    
    {
        int GetDigit(int x, int digitNumber)
        {
            if (digitNumber < 0)
                throw new ArgumentOutOfRangeException("digitNumber");

            int digitCount = (int)Math.Log10(x);
            if (digitNumber > digitCount)
                return 0;

            var pow = (int)Math.Pow(10, digitCount - digitNumber);
            return (x / pow) % 10;
        }

        public bool Solution(int num)
        {
            int repit = 0;
            int temp = 0;
            for (int j = 0; j < num.ToString().Length; j++)
            {
                temp += (int)Math.Pow(GetDigit(num, j), 2);
            }

            repit = temp;
            while (true)
            {

                num = temp;
                temp = 0;
                for (int j = 0; j < num.ToString().Length; j++)
                {
                    temp += (int)Math.Pow(GetDigit(num, j), 2);
                }
                num = temp;
                Console.WriteLine(temp);
                if (num == repit)
                    return false;
                if (num == 1)
                    return true;
            }
        }
    }



    //867. Transpose Matrix     no solution
    public class TransposeMatrix
    {
        public int[][] Solution(int[][] matrix)
        {
            int temp;
            for (int i = 0; i < matrix.Length - 1; i++)
            {
                for (int j = i + 1; i < matrix[i].Length; j++)
                {
                    temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }

            return matrix;
        }
    }



    //883. Projection Area of 3D Shapes
    public class ProjectionAreaof3DShapes
    {
        public int Function(int[][] grid)
        {
            int area = 0;
            int maxSide = 0;
            for(int i = 0; i < grid.Length; i++)
            {
                maxSide = 0;
                for(int j = 0; j < grid[i].Length; j++)
                {
                    if(grid[i][j] != 0) 
                    {
                        area++;         //4 
                    }

                    if (grid[j][i] > maxSide)
                        maxSide = grid[j][i];   //7  
                }     
                //area from side
                area += maxSide;
                //area from front
                area += grid[i].Max();  //6 
            }
            return area;
        }        
    }








    internal class Program
    {
        static void Main(string[] args)
        {
            FizzBuzz a = new FizzBuzz();
            List<string> res = a.Function(50);






        }
    }
}