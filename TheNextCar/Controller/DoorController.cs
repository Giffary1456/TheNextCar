using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Navigation;
using TheNextCar.Model;

namespace TheNextCar.Controller
{
    class DoorController
    {
        private Door door;
        private OnDoorChanged callbackOnDoorChanged;

        public DoorController(OnDoorChanged callbackOnDoorChanged)
        {
            this.callbackOnDoorChanged = callbackOnDoorChanged;
            this.door = new Door();
        }

        public void close()
        {
            this.door.close();
            this.callbackOnDoorChanged.onDoorOpenStateChanged("CLOSED", "door closed");
        }

        public void open()
        {
            this.door.open();
            this.callbackOnDoorChanged.onDoorOpenStateChanged("OPENED", "door opened");
        }

        public void activateLock()
        {
            this.door.activeatelock();
            this.callbackOnDoorChanged.onlockDoorStateChanged("LOCKED", "door locked");
        }


        public void unlock()
        {
            this.door.unlock();
            this.callbackOnDoorChanged.onlockDoorStateChanged("UNLOCKED", "door unlocked");
        }
        public bool isclose()
        {
            return this.door.isclosed();
        }
        public bool islocked()
        {
            return this.door.islocked();
        }

    }

    interface OnDoorChanged
    {
        void onlockDoorStateChanged(string value, string message);
        void onDoorOpenStateChanged(string value, string message);
    }
}
