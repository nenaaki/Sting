using System;
using System.Collections.Generic;

namespace Sting.Controls.Panel
{
    public class WeakVirtualElement
    {
        private static int _nextId;

        private int _id;
        public WeakVirtualElement(ControlBase virtualElement)
        {
            _virtualElement = new WeakReference(virtualElement);

            _id = _nextId++;
        }

        WeakReference _virtualElement;

        public bool IsAlive()
        {
            return _virtualElement.IsAlive;
        }

        public override int GetHashCode()
        {
            return _id;
        }
    }

    public class AttachedPropertyBase
    {
        protected static List<Action<int>> _compactionList = new List<Action<int>>();

        protected static List<Func<int>> _getCountList = new List<Func<int>>();


        public static void CompactionAll()
        {
            foreach (var compaction in _compactionList)
            {
                compaction(int.MaxValue);
            }
        }

        public static int GetCountAll()
        {
            int count = 0;
            foreach (var getCount in _getCountList)
            {
                count += getCount();
            }
            return count;
        }
    }


    public class AttachedProperty<T> : AttachedPropertyBase
    {
        static AttachedProperty()
        {
            _compactionList.Add(Compaction);
            _getCountList.Add(() => _properties.Count);
        }

        private static Dictionary<WeakVirtualElement, T> _properties = new Dictionary<WeakVirtualElement, T>();

        public T GetValue(WeakVirtualElement element)
        {
            T val;
            _properties.TryGetValue(element, out val);
            return val;
        }

        public void SetValue(WeakVirtualElement element, T val)
        {
            if (_properties.ContainsKey(element))
                _properties[element] = val;
            else
                _properties.Add(element, val);
        }

        private static void Compaction(int count)
        {
            var wveArray = new WeakVirtualElement[Math.Min(count, _properties.Count)];
            int counter = 0;
            foreach (var key in _properties.Keys)
            {
                if (key.IsAlive())
                    continue;
                wveArray[counter++] = key;

                if (counter >= wveArray.Length)
                    break;
            }
            foreach (var key in wveArray)
            {
                if (key == null)
                    break;

                _properties.Remove(key);
            }
        }
    }
}
