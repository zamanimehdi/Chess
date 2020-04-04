using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public struct BeadPosition
    {
        /// <summary>
        /// نگهدارنده موقعیت یک خانه روی برد به صورتی که تعیین کننده خانه ای روی برد میباشد
        /// مثلا 7*3 که نشان میدهد ستون سوم و ردیف هفتم
        /// </summary>
        byte x;
        byte y;
        /// <summary>
        /// ساخت یک نمونه جدید با مقدار نمونه ارسال شده
        /// </summary>
        /// <param name="one">نمونه ی الگو برای کپی برداری</param>
        public BeadPosition(BeadPosition one)
        {
            x = one.x;
            y = one.y;
        }
        /// <summary>
        /// مقدار دهی اولیه
        /// </summary>
        /// <param name="x">شماره ستون</param>
        /// <param name="y">شماره سطر</param>
        public BeadPosition(byte x, byte y)
        {
            this.x = x;
            this.y = y;
        }
        public static bool operator ==(BeadPosition one, BeadPosition two)
        {
            if (one.X == two.X && one.Y == two.Y)
                return true;
            else
                return false;
        }
        public static bool operator !=(BeadPosition one, BeadPosition two)
        {
            if (one.X == two.X && one.Y == two.Y)
                return false;
            else
                return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        // این متد موقع استفاده از متد کآنتین استفاده میشه
        public override bool Equals(object obj)
        {
            if (((BeadPosition)obj).X == X && ((BeadPosition)obj).Y == Y)
                return true;
            else
                return false;
        }
        public void setNull()
        {
            X = Y = 0;
        }
        public byte X
        {
            set
            {
                x = value;
            }
            get
            {
                return x;
            }
        }
        public byte Y
        {
            set
            {
                y = value;
            }
            get
            {
                return y;
            }
        }
    }
}