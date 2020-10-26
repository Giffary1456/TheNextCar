using System;
using System.Collections.Generic;
using System.Text;

namespace TheNextCar.Model
{
    class Door
    {
        private bool locked;
        private bool closed;
        public void close()
        {
            this.closed = true;
        }

        public void open()
        {
            this.closed = false;
        }

        public void activeatelock()
        {
            this.locked = true;
        }

        public void unlock()
        {
            this.locked = false;
        }
        public bool islocked()
        {
            return this.locked;
        }
        public bool isclosed()
        {
            return this.closed;
        }
    }
}
