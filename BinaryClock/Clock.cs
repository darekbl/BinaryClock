﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BinaryClock
{
    class Clock
    {
        public int hour = DateTime.Now.Hour;
        public int minutes = DateTime.Now.Minute;

        public long byteHour = DateTime.Now.ToBinary();


        public bool[] getBinaryHour()
        {
            hour = DateTime.Now.Hour;

            int rest = hour;
            bool[] binaryHour = new bool[4];


            /*
             * Preparing hour
             */
            if (hour % 12 > 0)
            {
                hour = hour % 12;
            }

            int h = 8;
            int i = 0;

            while (i <= 3)
                    {
                        if (hour/h >= 1)
                            {
                                binaryHour[i] = true;
                                hour = hour % h;
                            }
                            else
                                {
                                    binaryHour[i] = false;
                                }

                        i++;
                        h = h/2;
                    }

            return binaryHour;
        }

        public bool[] getBinaryMinutes()
        {
            minutes = DateTime.Now.Minute;

            int rest = minutes;
            bool[] binaryMinutes = new bool[6];

            int m = 32;
            int i = 0;

            while (i <= 5)
            {
                if (minutes / m >= 1)
                {
                    binaryMinutes[i] = true;
                    minutes = minutes % m;
                }
                else
                {
                    binaryMinutes[i] = false;
                }

                i++;
                m = m / 2;
            }

            return binaryMinutes;
        }

        public bool isPM()
        {
            if (DateTime.Now.Hour/12 > 0)
                return true;
            else
                return false;
        }
    }
}
