using System;
using System.Text;

namespace NumberArray
{
    public class ArrayOfNumbers
    {
        private int[] numbers;

        // Constructor 1: Initializes array with specified size and all elements set to zero
        public ArrayOfNumbers(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Size must be greater than zero.");

            }
            numbers = new int[size];
        }

        // Constructor 2: Creates a copy of the input array
        public ArrayOfNumbers(int[] inputArray)
        {
            if (inputArray == null)
            {
                throw new ArgumentNullException(nameof(inputArray));
            }

            numbers = new int[inputArray.Length];
            for (int i = 0; i < inputArray.Length; i++)
            {
                numbers[i] = inputArray[i];
            }
        }

        // Accessor method: Get element at specified index
        public int GetElement(int index)
        {
            ValidateIndex(index);
            return numbers[index];
        }

        // Accessor method: Set element at specified index
        public void SetElement(int index, int value)
        {
            ValidateIndex(index);
            numbers[index] = value;
        }

        // Method: Returns the largest value in the array
        public int Max()
        {
            if (numbers.Length == 0)
                throw new InvalidOperationException("Array is empty.");

            int max = numbers[0];
            foreach (int num in numbers)
            {
                if (num > max)
                    max = num;
            }
            return max;
        }

        // Method: Checks if two elements at specified indices are equal
        public bool Equal(int index1, int index2)
        {
            ValidateIndex(index1);
            ValidateIndex(index2);
            return numbers[index1] == numbers[index2];
        }

        // Method: Calculates the greatest common divisor (GCD) of two elements
        public int GCD(int index1, int index2)
        {
            ValidateIndex(index1);
            ValidateIndex(index2);

            int a = Math.Abs(numbers[index1]);
            int b = Math.Abs(numbers[index2]);

            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        // Method: Returns the number of elements in the array
        public int Count()
        {
            return numbers.Length;
        }

        // Method: Returns the sum of all elements in the array
        public int Sum()
        {
            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }
            return sum;
        }

        // Method: Returns the average value of the elements in the array
        public double Average()
        {
            if (numbers.Length == 0)
            {
                throw new InvalidOperationException("Array is empty.");
            }
            return (double)Sum() / Count();
        }

        // Method: Returns a string representation of the array
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("[");
            for (int i = 0; i < numbers.Length; i++)
            {
                sb.Append(numbers[i]);
                if (i < numbers.Length - 1)
                    sb.Append(", ");
            }
            sb.Append("]");
            return sb.ToString();
        }

        // Mutator method: Multiplies each element of the array by a scalar
        public void ScalarMultiply(int scalar)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] *= scalar;
            }
        }

        // Mutator method: Adds a constant to each element of the array
        public void AddConstant(int constant)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] += constant;
            }
        }


        // Helper method: Validates an index is within bounds
        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= numbers.Length)
            {
                throw new IndexOutOfRangeException("Index is out of bounds.");
            }
        }
    }
}
