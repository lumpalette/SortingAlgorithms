using System.Diagnostics;

namespace ITACheck.Semestre3;

public class Program
{
	public static void Main(string[] args)
	{
		const int n = 1_000_000;
		int[] array = new int[n];
		RandomizeArray(array);
		TestAlgorithm(array, (array) => QuickSort(array, 0, array.Length - 1), "Quick sort");
	}

	#region Algorithms

	/// <summary>
	/// Ordena un array de enteros usando el algoritmo de ordenamiento Bubble sort.
	/// </summary>
	/// <param name="array">El array a ordenar.</param>
	private static void BubbleSort(int[] array)
	{
		for (int i = 0; i < array.Length - 1; i++)
		{
			bool swapped = false;
			for (int j = 0; j < array.Length - i - 1; j++)
			{
				if (array[j] > array[j + 1])
				{
					(array[j + 1], array[j]) = (array[j], array[j + 1]);
					swapped = true;
				}
			}
			if (!swapped)
			{
				break;
			}
		}
	}

	/// <summary>
	/// Ordena un array de enteros usando el algoritmo de ordenamiento Selection sort.
	/// </summary>
	/// <param name="array">El array a ordenar.</param>
	private static void SelectionSort(int[] array)
	{
		for (int i = 0; i < array.Length - 1; i++)
		{
			int minIndex = i;
			for (int j = i + 1; j < array.Length; j++)
			{
				if (array[j] < array[minIndex])
				{
					minIndex = j;
				}
			}
			(array[minIndex], array[i]) = (array[i], array[minIndex]);
		}
	}

	/// <summary>
	/// Ordena un array de enteros usando el algoritmo de ordenamiento Insertion sort.
	/// </summary>
	/// <param name="array">El array a ordenar.</param>
	private static void InsertionSort(int[] array)
	{
		for (int i = 1; i < array.Length; ++i)
		{
			int current = array[i];
			int j = i - 1;
			while (j >= 0 && array[j] > current)
			{
				array[j + 1] = array[j];
				j--;
			}
			array[j + 1] = current;
		}
	}

	/// <summary>
	/// Ordena un array de enteros usando el algoritmo de ordenamiento Quick sort.
	/// </summary>
	/// <param name="array">El array a ordenar.</param>
	private static void QuickSort(int[] array, int low, int high)
	{
		// dude wtf how is this thing so fast
		int i = low;
		int j = high;
		int pivot = array[low];
		while (i <= j)
		{
			while (array[i] < pivot)
			{
				i++;
			}
			while (array[j] > pivot)
			{
				j--;
			}
			if (i <= j)
			{
				(array[j], array[i]) = (array[i], array[j]);
				i++;
				j--;
			}
		}
		if (low < j)
		{
			QuickSort(array, low, j);
		}
		if (i < high)
		{
			QuickSort(array, i, high);
		}
	}

	#endregion

	#region Tests

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

	#endregion
}