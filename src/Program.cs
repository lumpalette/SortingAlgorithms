using System.Diagnostics;

namespace ITACheck.Semestre3;

public class Program
{
	public static void Main(string[] args)
	{
		const int n = 1_000_000;
		int[] array = new int[n];
		RandomizeArray(array);
		TestAlgorithm(array, (array) => Algorithms.QuickSort(array, 0, array.Length - 1), "Quick sort");
	}

	private static void RandomizeArray(int[] array)
	{
		Random random = new();
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = random.Next();
		}
	}

	private static void TestAlgorithm(int[] array, Action<int[]> algorithm, string algorithmName)
	{
		// measure sorting time.
		Stopwatch watch = Stopwatch.StartNew();
		algorithm(array);
		watch.Stop();
		Console.WriteLine($"Tiempo de ejecución ({algorithmName}, {array.Length} elementos): {watch}");

		// ensure the algorithm sorted the array correctly.
		Console.WriteLine($"Muestra de 100 elementos en la mitad del array:");
		for (int i = 0; i < 100; i++)
		{
			Console.Write(array[(array.Length / 2) + i]);
			if (i + 1 != 100) // todo nye
			{
				Console.Write(", ");
			}
		}
	}
}