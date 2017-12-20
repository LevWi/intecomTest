using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intecomTest
{
    // Ячейка в массиве с полями "время" и "значение"
    struct ArhivePoint
    {
        public double Data { private set; get; }

        public DateTime DateTimePoint { private set; get; }

        public ArhivePoint(double dataArr, DateTime dt)
        {
            Data = dataArr;
            DateTimePoint = dt;
        }
    }

    /* Архив
     * 
     * Работа по кругу. Инициализируется с конкретным размером
     * При переполнении начинает перетирать старые элементы, начиная с нулевого
     * 
     */
    class TimeArhive {

        bool filled = false;
        int currentIndex = -1;

        ArhivePoint[] arhiveArr;

        public TimeArhive(int size)
        {
            arhiveArr = new ArhivePoint[size];
        }

        // Добавить элемент в конец
        public void EnqueueLast(ArhivePoint elem)
        {
            currentIndex++;
            if (currentIndex > arhiveArr.Length - 1)
            {
                currentIndex = 0;
                filled = true;
            }
            arhiveArr[currentIndex] = elem;
        }

        public int FirstIndex
        {
            get
            {
                if (filled)
                {
                    return (currentIndex <= arhiveArr.Length - 1) ? currentIndex + 1 : 0;
                }
                return this.Empty ? -1 : 0;
            }
        }

        public bool Empty
        {
            get { return currentIndex < 0; }
        }

        // Поиск ближайшего индекса в массиве по временной точке
        // недоделал...
        public int GetNearestIndexFromTimePoint(DateTime dt)
        {
            if (this.Empty){
                return -1;
            }
            if (arhiveArr[currentIndex].DateTimePoint == dt)
            {
                return currentIndex;
            }
            else if (arhiveArr[currentIndex].DateTimePoint > dt)
            {
                if (arhiveArr[FirstIndex].DateTimePoint > dt) // временная точка за границами архива 
                {
                    return -1;
                }

                // приблизительный сдвиг от текущего положения в массиве
                int index_shift = (arhiveArr[currentIndex].DateTimePoint - dt).Seconds;

                int newIndex;
                if (index_shift > arhiveArr.Length)
                {
                    newIndex = FirstIndex; 
                }
                else
                { 
                    newIndex = currentIndex - index_shift;
                    if (newIndex < 0)
                    {
                        newIndex = newIndex + arhiveArr.Length - 1;
                    }
                }
                for(int i = 0; i < arhiveArr.Length; i++)
                {
                    arhiveArr[newIndex].DateTimePoint
                }
            }
        }

        // недоделал...
        private int NextIndex(int index)
        {            
            if (filled)
            {
                return index < currentIndex ? index + 1 :
                    () ;
            }
            if (index >= currentIndex)
            {
                return -1;
            }
        }

        public double GetAvgData(DateTime dt_start, DateTime dt_end)
        {
            // Первый элемент
            int start_index = 0;
            
            arhiveArr[currentIndex].DateTimePoint 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
