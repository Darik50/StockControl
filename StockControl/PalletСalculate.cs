using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl
{
    public class PalletСalculate
    {
        /// <summary>
        /// Выполняет вычисления веса паллеты.
        /// </summary>
        /// <param name="boxes">Список коробок. Массив объектов типа Box.</param>
        /// <returns>Вес паллеты.</returns>
        public int WeightСalculate(List<Box> boxes)
        {
            int weight = 30;
            foreach (Box box in boxes) 
            { 
                weight += box.Weight;
            }
            return weight;
        }
        /// <summary>
        /// Выполняет вычисления срока годности паллеты.
        /// </summary>
        /// <param name="boxes">Список коробок. Массив объектов типа Box.</param>
        /// <returns>Срок годности паллеты.</returns>
        public DateTime? BeforeDateСalculate(List<Box> boxes)
        {
            DateTime? date = null;
            DateTime?[] dateTimes = new DateTime?[boxes.Count];
            for(int i =0; i < boxes.Count; i++)
            {
                if (boxes[i].BeforeDate != null)
                    dateTimes[i] = boxes[i].BeforeDate;
                else
                    dateTimes[i] = boxes[i].DateCreation.Value.AddDays(100);
            }
            date = dateTimes.Min();
            return date;
        }
        /// <summary>
        /// Выполняет вычисления объема паллеты.
        /// </summary>
        /// <param name="boxes">Список коробок. Массив объектов типа Box.</param>
        /// <returns>Объем паллеты.</returns>
        public int VolumeСalculate(List<Box> boxes)
        {
            int volume = 0;
            foreach (Box box in boxes)
            {
                volume += box.Volume;
            }
            return volume;
        }
    }
}
