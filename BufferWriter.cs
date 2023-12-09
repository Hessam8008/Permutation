using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutation
{
    public sealed class BufferWriter
    {
        private static BufferWriter _instance;
        public const string FileName = "result.txt";
        public static BufferWriter GetInstance(int total)
        {
            _instance ??= new BufferWriter(total);
            return _instance;
        }

        private readonly List<string> _buffer;
        private int _counter = 0;
        private int _total = 0;
        private int _rows = 0;

        private BufferWriter(int total)
        {
            File.Delete(FileName);
            _buffer = new List<string>();
            _total = total;
        }

        public void Add(string str)
        {
            _buffer.Add(str);
            _counter++;
            if (_counter >= 1_000_000)
            {
                Save();
                Clear();
                _rows += _counter;
                _counter = 0;
            }
        }

        public void Save()
        {
            var output = string.Join(Environment.NewLine, _buffer);
            File.AppendAllText(FileName, output);
            Console.WriteLine($"Write buffer {_rows} of {_total} [{1.0*_rows / _total * 100:00.0}%] ...");
        }

        public void Clear()
        {
            _buffer.Clear();

        }

    }
}
