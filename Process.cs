using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    class ProcessClass
    {
        private string name;
        private int id;
        private long memoryUsage;
        private DateTime startTime;
        private DateTime runningTime;
        private string commentary;
        private TimeSpan timeSpan;
        private ProcessThreadCollection threads;

        public ProcessClass(string name, int id, long memoryUsage, DateTime startTime)
        {
            this.name = name;
            this.id = id;
            this.memoryUsage = memoryUsage;
            this.startTime = startTime;
            this.commentary = null;
        }

        public ProcessClass(string name, int id, long memoryUsage, DateTime startTime, TimeSpan timeSpan) : this(name, id, memoryUsage, startTime)
        {
            this.timeSpan = timeSpan;
        }

        public ProcessClass(string name, int id, long memoryUsage, DateTime startTime, TimeSpan timeSpan, ProcessThreadCollection threads) : this(name, id, memoryUsage, startTime, timeSpan)
        {
            this.Threads = threads;
        }

        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
        public long MemoryUsage { get => memoryUsage; set => memoryUsage = value; }
        public DateTime StartTime { get => startTime; set => startTime = value; }
        public DateTime RunningTime { get => runningTime; set => runningTime = value; }
        public ProcessThreadCollection Threads { get => threads; set => threads = value; }
        public string Commentary { get => commentary; set => commentary = value; }
    }
}
