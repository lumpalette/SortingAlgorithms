namespace ITACheck.Semestre3;

public static class Algorithms
{
	/// <summary>
	/// Ordena un array de enteros usando el algoritmo de ordenamiento Bubble sort.
	/// </summary>
	/// <param name="array">El array a ordenar.</param>
	public static void BubbleSort(int[] array)
	{
		// frick you
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
	public static void SelectionSort(int[] array)
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
	public static void InsertionSort(int[] array)
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
	public static void QuickSort(int[] array, int low, int high)
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
}