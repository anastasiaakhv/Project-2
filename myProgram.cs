using System;
using System.Collections.Generic;
using System.Text;

// Class MyList represents class Infint
public class MyList
{

    private List<int> TheIntegerList = new List<int>();


    public void TheList(string MyString)
    {
        // find out length of a string
        int n = MyString.Length;

        /*   Create a new list of integers - reading every character line by line 
         *   and adding to the list
         */

        for (int i = 0; i <= (n - 1); i++)
        {
            TheIntegerList.Add((int)Char.GetNumericValue(MyString[i]));
        }

       //TheIntegerList.ForEach(Console.Write); // display the values  
    }

    public int CompareMyString(string one, string two)
    {
        /*
         If str1 is less than str2, it returns -1.

         If str1 is equal to str2, it returns 0.

         If str1 is greater than str2, it returns 1. 

         */

        int a;
        a = String.Compare(one, two);
        return a;
    }

    public string CompareLengths(string one, string two)
    {
        /* the purpose of this function is to pad the leading zeros
         * to a number which is less than the other
         */

        int firstLength = one.Length;
        int secondLength = two.Length;

        
        if (firstLength == secondLength)
        {
            return "The Lengths are the same size";
        }
        else if (firstLength < secondLength)
        {
            one = one.PadLeft(two.Length, '0');
            return one;
        }
        else if (firstLength > secondLength)
        {
            two = two.PadLeft(one.Length, '0');
            return two;
        }

        // The two strings are of same lengths now

        else return "error";
    }

    public static void MyMultiplication(MyList First, MyList Second)
    {
        /*
         * This function takes two strings
         * the product of the corresponding strings is stored into a list
         * Lastly the function displayes the resulting list
         */

        List<int> MyFirst = new List<int>();
        List<int> MySecond = new List<int>();

        int myfirst = 0;
        int mysecond = 0;

        for (int s = 0; s <= (First.TheIntegerList.Count - 1); s++)
        {
            myfirst = First.TheIntegerList[s];
            MyFirst.Add(myfirst);
        }

        for (int s = 0; s <= (Second.TheIntegerList.Count - 1); s++)
        {
            mysecond = Second.TheIntegerList[s];
            MySecond.Add(mysecond);
        }

        

        //Get the length of both strings
        int lenfirst = MyFirst.Count;
        int lensecond = MySecond.Count;

        // declaring an integer array - purpose: using it as a container  
        int[] MyResult = new int[lenfirst + lensecond];

        //local variables - purpose: find the positions in the array MyResult 
        int pos1 = 0;
        int pos2 = 0;

        int i;
        // traverse from right to left
        for (i = lenfirst - 1; i >= 0; i--)
        {
            int carry = 0;
            //appropriate digit of the first operand
            int myFirst = MyFirst[i] - 0;
            // shift - following the original long multiplication algorithm 
            pos2 = 0;
            // traverse from right to left          
            for (int m = lensecond - 1; m >= 0; m--)
            {
                //appropriate digit of the second operand
                int mySecond = MySecond[m] - 0
                    ;
                //follow the long multiplication algorithm and sum up
                int TheSum = myFirst * mySecond + MyResult[pos1 + pos2] + carry;
                // Reset carry flag
                carry = TheSum / 10;
                // Store result in my array at the corresponding position
                MyResult[pos1 + pos2] = TheSum % 10;
                pos2++;
            }
            if (carry > 0) MyResult[pos1 + pos2] = MyResult[pos1 + pos2] + carry;
            //shift after every iteration
            pos1++;
        }
        //ignoring leading zeros
        for (i = MyResult.Length - 1; i >= 0 && MyResult[i] == 0; i--);
        // the case where the result = 0 
        if (i == -1) Console.WriteLine("The result is 0");

        // Create a list storing the resulting infint
        List<int> Result = new List<int>();
        while (i >= 0) Result.Add(MyResult[i--]);
        // Display the resulting infint
        Result.ForEach(Console.Write);
    }

    public static void DifferentSign(string first, string second)
    {   // this function is called when the two operands have different signs

        // get numerical value of the first entry of the passed string 
        int a = (int)(Char.GetNumericValue(first[0]));

        //if a has negative sign (minus)
        if (Math.Sign(a) < 0)
        {
            //take the module of the number
            first = first.Remove(0, 1);
            //Console.WriteLine(first);
            MyList newfirst = new MyList();
            MyList newsecond = new MyList();

            // set both strings to same lengths
            if (first.Length < second.Length)
            {
                first = newfirst.CompareLengths(first, second);
            }
            else if (first.Length > second.Length)
            {
                second = newfirst.CompareLengths(first, second);
            }

            
            newfirst.TheList(first);
            
            newsecond.TheList(second);

            int option = newfirst.CompareMyString(first, second);

            switch (option)
            {
                case 1:
                    
                    Console.Write("-");
                    newfirst.subtract_FirstGreater(newfirst, newsecond);
                    break;
                case 0:
                    Console.WriteLine("The result is 0 ");
                    break;
                case -1:
                    

                    newfirst.subtract_FirstGreater(newsecond, newfirst);

                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }

        // do the same if the second operand has the minus sign
        int b = (int)(Char.GetNumericValue(second[0]));

        if (Math.Sign(b) < 0)
        {
            second = second.Remove(0, 1);
            //Console.WriteLine(second);


            MyList newfirst = new MyList();
            MyList newsecond = new MyList();
            if (first.Length < second.Length)
            {
                first = newfirst.CompareLengths(first, second);
            }
            else if (first.Length > second.Length)
            {
                second = newfirst.CompareLengths(first, second);
            }


            
            newfirst.TheList(first);
            newsecond.TheList(second);
            
            
            int p = newfirst.CompareMyString(first, second);

            switch (p)
            {
                case 1:
                    
                    newfirst.subtract_FirstGreater(newfirst, newsecond);
                    break;
                case 0:
                    Console.Write("The result is 0 ");
                    break;
                case -1:
                    
                    Console.Write("-");
                    newfirst.subtract_FirstGreater(newsecond, newfirst);

                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }

    }

    // addition function
    // parameters two objecst of MyList (Infint)
    public void addition(MyList First, MyList Second)
    {
        // create a list that will store the result
        List<int> Result = new List<int>();

        // Declare integer myfirst and set it to 0 
        int myfirst = 0;
        // Declare integer mysecond and set it to 0 
        int mysecond = 0;

        //perform addition of two numbers
        for (int s = 0; s <= (TheIntegerList.Count - 1); s++)
        {
            myfirst = First.TheIntegerList[s];
            mysecond = Second.TheIntegerList[s];
            int myresult = myfirst + mysecond;
            Result.Add(myresult);
        }



        for (int i = ((Result.Count) - 1); i >= 1; i--)
        {
            // if the node is holding a value that is greater than ten
            if (Result[i] >= 10)
            {

                //rearrange the list in the correct order - correct the carry situation
                Result[i] = Result[i] % 10;
                Result[i - 1] = Result[i - 1] + 1;
            }
        }

        // do the same for the first node of the Result list
        if (Result[0] >= 10)
        {
            List<int> NewResult = new List<int>((Result.Count) + 1);
            for (int i = 0; i < ((Result.Count) + 1); i++) NewResult.Add(0);


            NewResult[0] = 1;
            NewResult[1] = Result[0] % 10;


            //Result.ForEach(Console.Write);

            //shift the resul list by one to the right
            for (int j = 2; j < (Result.Count + 1); j++)
            {
                NewResult[j] = Result[j - 1];
            }


            //display the new list with the rearranged correct values
            NewResult.ForEach(Console.Write);
        }

        else
        {

            // if the above mentioned are not needed
            // display the result list which is already arranged in a correct manner
            Result.ForEach(Console.Write);
        }


    }

    public static void SameMinusSign(string first, string second)
    {
        //this function is called when both infints are negative and the operation is +

        /* the idea of this function is to determine that both operands have 
         * minus sign in front of them.
         * after determining the minus sign, the program removes it and adds the
         * two numbers.
         * the result is the sum with a minus sign 
         */

        //get the values of the first entries of both strings
        int a = (int)(Char.GetNumericValue(first[0]));
        int b = (int)(Char.GetNumericValue(second[0]));

        // instantiate objects
        MyList newfirst = new MyList();
        MyList newsecond = new MyList();


        //remove the minus sign from the number 
        first = first.Remove(0, 1);
        second = second.Remove(0, 1);

        //set the two numbers to the same lenth - pad with 0s from the left
        if (first.Length < second.Length)
        {
            first = newfirst.CompareLengths(first, second);
        }
        else if (first.Length > second.Length)
        {
            second = newfirst.CompareLengths(first, second);
        }

        //Call TheList function - pass the first string
        newfirst.TheList(first);
        
        //Call TheList function - pass the second string
        newsecond.TheList(second);

       
        
        //put the minus sign in front of the result
        Console.Write("-");
        //perform addition of the two operands
        newfirst.addition(newfirst, newsecond);

    }


    public static void Minuss(string first, string second)
    {
        // this function is called when both operands have negative sign and the operation is -

        //Instantiate objects
        MyList newfirst = new MyList();
        MyList newsecond = new MyList();

        //remove the minus sign 
        first = first.Remove(0, 1);
        second = second.Remove(0, 1);

        //Set both strings to same lengths
        if (first.Length < second.Length)
        {
            first = newfirst.CompareLengths(first, second);
        }
        else if (first.Length > second.Length)
        {
            second = newfirst.CompareLengths(first, second);
        }

        //Call TheList function - pass the first string
        newfirst.TheList(first);
        
        //Call TheList function - pass the second string
        newsecond.TheList(second);

        int option = newfirst.CompareMyString(first, second);
        //Different cases when subtracting
        switch (option)
        {
            case 1:
                
                Console.Write("-");
                newfirst.subtract_FirstGreater(newfirst, newsecond);
                break;
            case 0:
                Console.Write("The result is 0 ");
                break;
            case -1:
                
                Console.Write("-");
                newfirst.subtract_FirstGreater(newsecond, newfirst);

                break;
            default:
                Console.WriteLine("Default case");
                break;
        }



    }

    public static void DiffMinus(string first, string second)
    {
        //this function is called when two operands have different signs
        //operation is -

        //Instantiate objects

        MyList newfirst = new MyList();
        MyList newsecond = new MyList();

        //when first operand is negative
        if ((first[0] == '-') && !(second[0] == '-'))
        {
            //remove the minus sign
            first = first.Remove(0, 1);

            //same lengths
            if (first.Length < second.Length)
            {
                first = newfirst.CompareLengths(first, second);
            }
            else if (first.Length > second.Length)
            {
                second = newfirst.CompareLengths(first, second);
            }

            newfirst.TheList(first);
            newsecond.TheList(second);
            
            Console.Write("-");
            //perform addition
            //two objects are passed to this function
            newfirst.addition(newfirst, newsecond);
        }

        //when second operand is negative
        if (!(first[0] == '-') && (second[0] == '-'))
        {
            //remove minus
            second = second.Remove(0, 1);

            if (first.Length < second.Length)
            {
                first = newfirst.CompareLengths(first, second);
            }
            else if (first.Length > second.Length)
            {
                second = newfirst.CompareLengths(first, second);
            }

            newfirst.TheList(first);
            newsecond.TheList(second);
            
            newfirst.addition(newfirst, newsecond);
        }



    }



    public void subtract_FirstGreater(MyList MyFirst, MyList MySecond)
    {
        // Create three containers - lists
        List<int> Result = new List<int>();
        List<int> First = new List<int>();
        List<int> Second = new List<int>();

        //fill the lists First and Second with the numeric values of the correspondin Integerlists
        for (int s = 0; s <= (TheIntegerList.Count - 1); s++)
        {
            First.Add(MyFirst.TheIntegerList[s]);
            Second.Add(MySecond.TheIntegerList[s]);
        }

        // declare integer myresult and set it to 0 
        int myresult = 0;

        //starting from index one perform the operation subtraction
        // iterate until the end of the list
        for (int i = 1; i <= First.Count; i++)
        {
            /*
             * if the first operand is less than second operand
             * "loan" ten from the previous number
             * subtract 1 from the same previous number - Subtraction algorithm
             */


            if (First[(First.Count) - i] < Second[(Second.Count) - i])
            {
                First[(First.Count) - i] = First[(First.Count) - i] + 10;
                First[((First.Count) - i) - 1] = First[((First.Count) - i) - 1] - 1;
                myresult = First[(First.Count) - i] - Second[(Second.Count) - i];
                // store the result in List named Result
                Result.Add(myresult);
            }

            // else perform the usual subtraction
            else
            {
                myresult = First[(First.Count) - i] - Second[(Second.Count) - i];
                // store the result in List named Result
                Result.Add(myresult);
            }

        }

        // reverse the list
        Result.Reverse();
        // Display every node of the list
        Result.ForEach(Console.Write);
    }


    public static void MyFunction(string str, string firstop, string secondop)
    {
        // this function determines which operation has to be performed
        // and acts in the corresponding manner

        // If the operation is +
        if (str == "+")
        {
            // if both operands are positive
            if (!(firstop[0] == '-') && !(secondop[0] == '-'))
            {
                MyList first = new MyList();
                MyList second = new MyList();

                if (firstop.Length < secondop.Length)
                {
                    firstop = first.CompareLengths(firstop, secondop);
                }
                else if (firstop.Length > secondop.Length)
                {
                    secondop = first.CompareLengths(firstop, secondop);
                }

                first.TheList(firstop);
                
                second.TheList(secondop);
                
                // Call addition
                first.addition(first, second);
            }

            //if only one of the operands is negative
            if ((firstop[0] == '-') ^ (secondop[0] == '-'))
            {
                
                //Call the corresponding function - DifferentSign
                MyList.DifferentSign(firstop, secondop);
            }

            //if both operands are negative
            if ((firstop[0] == '-') && (secondop[0] == '-'))
            {
                
                //Call the corresponding function - SameMinusSign
                MyList.SameMinusSign(firstop, secondop);
            }

        }

        //if the operation is -
        if (str == "-")
        {
            // if both operands are positive
            if (!(firstop[0] == '-') && !(secondop[0] == '-'))
            {
                MyList first = new MyList();
                MyList second = new MyList();

                if (firstop.Length < secondop.Length)
                {
                    firstop = first.CompareLengths(firstop, secondop);
                }
                else if (firstop.Length > secondop.Length)
                {
                    secondop = first.CompareLengths(firstop, secondop);
                }

                
                first.TheList(firstop);
                
                second.TheList(secondop);
                
                //Choose the appropriate case
                int option = first.CompareMyString(firstop, secondop);
                switch (option)
                {
                    case 1:
                        Console.WriteLine();
                        first.subtract_FirstGreater(first, second);
                        break;
                    case 0:
                        Console.WriteLine("The result is 0 ");
                        break;
                    case -1:
                        Console.WriteLine();
                        Console.Write("-");
                        first.subtract_FirstGreater(second, first);

                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
            }

            // if only one of the operands is negative
            if ((firstop[0] == '-') ^ (secondop[0] == '-'))
            {
                
                //Call the corresponding function - DiffMinus
                MyList.DiffMinus(firstop, secondop);
            }


            // if both operands are negative
            if ((firstop[0] == '-') && (secondop[0] == '-'))
            {
                
                //Call the corresponding function - Minuss
                MyList.Minuss(firstop, secondop);
            }
        }

    }
}


namespace Infint.Anastasia.Akhvlediani
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Display the file contents to the console. Variable text is a string.
            string[] lines = System.IO.File.ReadAllLines(@"/Users/macssd/Desktop/infint.txt");



            int a = lines.Length;
            Console.WriteLine("There are {0} lines in the file", a);

            int b = a / 3;
            Console.WriteLine("There are {0} operations to test in the file", b);

            //testing the file 
            for (int k = 2; k <= 41; k = k + 3)
            {
                Console.WriteLine("\n--------------------");
                Console.WriteLine(lines[k - 2]);
                Console.WriteLine(lines[k - 1]);
                Console.WriteLine(lines[k]);

                Console.WriteLine();
                Console.WriteLine("SEE ANSWER BELOW:");
                MyList.MyFunction(lines[k], lines[k-2], lines[k-1]);
                Console.WriteLine("\n--------------------");
                Console.WriteLine("\n");
            }

            Console.WriteLine("\n");
            
            Console.WriteLine("Testing for the multiplication that was not provided in the file");
            Console.WriteLine();
            Console.WriteLine("Type in a number");
            string firstString = Console.ReadLine();
            Console.WriteLine("Type in another number");
            string secondString = Console.ReadLine();

            MyList newFirst = new MyList();
            MyList newSecond = new MyList();

            if ((firstString[0] == '-') && !(secondString[0] == '-'))
            {
                firstString = firstString.Substring(1);
                newFirst.TheList(firstString);
                newSecond.TheList(secondString);
                Console.Write("The operands have different signs   Answer: -");
                MyList.MyMultiplication(newFirst, newSecond);
            }


            else if (!(firstString[0] == '-') && (secondString[0] == '-'))
            {
                secondString = secondString.Substring(1);
                newFirst.TheList(firstString);
                newSecond.TheList(secondString);
                Console.Write("The operands have different signs   Answer: -");
                MyList.MyMultiplication(newFirst, newSecond);

            }
            else if (!(firstString[0] == '-') && !(secondString[0] == '-'))
            {
                newFirst.TheList(firstString);
                newSecond.TheList(secondString);
                Console.Write("The operands have + signs   Answer: ");
                MyList.MyMultiplication(newFirst, newSecond);
            }

            else if ((firstString[0] == '-') && (secondString[0] == '-'))
            {
                firstString = firstString.Substring(1);
                secondString = secondString.Substring(1);
                newFirst.TheList(firstString);
                newSecond.TheList(secondString);
                Console.Write("The operands have - signs   Answer: ");
                MyList.MyMultiplication(newFirst, newSecond);
            }

        }
}

}  // end of program
