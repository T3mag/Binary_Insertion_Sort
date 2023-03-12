namespace Binary_Insortion_Sort;

public static class Sort
{
    public class Program
    {
        public static void Main()
        {
            var mas = new int[] {1,2,3,4,5,7,2,10,5};
            
            for (int i = 0; i < mas.Length; i++)
                Console.Write(mas[i] + " ");

            Console.WriteLine();
            
            var mas1 = BinaryInsortionSort(mas);

            for (int i = 0; i < mas1.Length; i++)
                Console.Write(mas1[i] + " ");
        }
        
        public static int[] BinaryInsortionSort(int[] mas)
        {
            for (int i = 1; i < mas.Length; i++)
            {
                var low = 0;
                var high = i - 1;
                var cur = mas[i];

                while (low <= high)
                {
                    int mid = (low + high) / 2;

                    if (cur < mas[mid])
                        high = mid - 1;
                    else
                        low = mid + 1;
                }

                for (int j = i - 1; j >= low; j--)
                    mas[j + 1] = mas[j];
                
                mas[low] = cur;
            }

            return mas;
        }
        
    }
}
