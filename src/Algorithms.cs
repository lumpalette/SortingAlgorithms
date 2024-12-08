namespace ITACheck.Semestre3;

public static class Algorithms
{
	/// <summary>
	/// Ordena un array de enteros usando el algoritmo de ordenamiento Bubble sort.
	/// </summary>
	/// <param name="array">El array a ordenar.</param>
	public static void BubbleSort(int[] array)
	{
		for (int i = 0; i < array.Length - 1; i++)
		{
			// Compara elementos adyacentes para comprobar si el elemento actual (j) es mayor a su 
			// sucesor; si ese es el caso, los intercambia. El algoritmo ordena la lista de final a inicio.
			bool swapped = false;
			for (int j = 0; j < array.Length - i - 1; j++)
			{
				if (array[j] > array[j + 1])
				{
					(array[j + 1], array[j]) = (array[j], array[j + 1]);
					swapped = true;
				}
			}
			
			// Si no se intercambio ningún elemento, significa que la lista está ordenada.
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
		// Este algoritmo busca el elemento más pequeño dentro de la sublista no ordenada
		// y lo posiciona en su lugar correspondiente.
		for (int i = 0; i < array.Length - 1; i++)
		{
			// Se asume que el elemento 'i' es el menor.
			int minIndex = i;
			for (int j = i + 1; j < array.Length; j++)
			{
				// Actualizar minIndex si existe un elemento
				if (array[j] < array[minIndex])
				{
					minIndex = j;
				}
			}

			// El elemento más pequeño de la sublista se posiciona correctamente y se remueve de la sublista
			// no ordenada.
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

			// Mientras haya elementos en la parte ordenada y el valor actual sea menor que el elemento comparado...
			while ((j >= 0) && (array[j] > current))
			{
				// ... desplazamos el elemento hacia la derecha para hacer espacio para el elemento actual.
				array[j + 1] = array[j];
				j--;
			}

			// Insertamos el elemento actual en su posición correcta dentro de la parte ordenada.
			array[j + 1] = current;
		}
	}

	/// <summary>
	/// Ordena un array de enteros usando el algoritmo de ordenamiento Quick sort.
	/// </summary>
	/// <param name="array">El array a ordenar.</param>
	public static void QuickSort(int[] array, int low, int high)
	{
		int i = low;
		int j = high;

		// El pivote se elige como el primer elemento del array.
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

			// Si 'i' aún no ha sobrepasado a 'j', intercambiamos los elementos en 'i' y 'j'
			if (i <= j)
			{
				(array[j], array[i]) = (array[i], array[j]);

				// Se desplazan los índices para procesar los elementos siguientes y anteriores.
				i++;
				j--;
			}
		}

		// Se ordena la partición izquierda si es necesario.
		if (low < j)
		{
			QuickSort(array, low, j);
		}

		// Se ordena la partición derecha si es necesario.
		if (i < high)
		{
			QuickSort(array, i, high);
		}
	}
}