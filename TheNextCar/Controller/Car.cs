using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TheNextCar.Controller
{
    class Car
    {
        private DoorController doorController;
        private AccubatteryController accubatteryController;
        private OnCarEngineStateChanged callback;

        public Car(DoorController doorController, AccubatteryController accubatteryController, OnCarEngineStateChanged callback)
        {
            this.doorController = doorController;
            this.accubatteryController = accubatteryController;
            this.callback = callback;
        }

        private bool doorIsClosed()
        {
            return this.doorController.isclose();
        }

        private bool doorIsLocked()
        {
            return this.doorController.islocked();
        }
        private bool powerIsRady()
        {
            return this.accubatteryController.accubatteryIsOn();
        }

        public void startEngine()
        {
            if (!doorIsClosed())
            {
                this.callback.onCarEngineStateChanged("STOPED", "close the door");
                return;
            }

            if (!doorIsLocked())
            {
                this.callback.onCarEngineStateChanged("SOTPED", "lock the door");
                return;
            }

            if (!powerIsRady())
            {
                this.callback.onCarEngineStateChanged("STOPED", "NO Power Available");
                return;
            }

            this.callback.onCarEngineStateChanged("STARTED", "Engine Stared");
        }

        public void toggleTheLockDoorButton()
        {
            if (!doorIsLocked())
            {
                this.doorController.activateLock();
            }
            else
            {
                this.doorController.unlock();
            }
        }

        public void toggleTheOpenDoorButton()
        {
            if (!doorIsClosed())
            {
                this.doorController.close();
            }
            else
            {
                this.doorController.open();
            }
        }

        public void toggleThePowerButton()
        {
            if (!powerIsRady())
            {
                this.accubatteryController.turnOn();
            }
            else
            {
                this.accubatteryController.turnOff();
            }
        }
    }
    interface OnCarEngineStateChanged
    {
        void onCarEngineStateChanged(string value, string message);
    }
}
