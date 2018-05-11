using System;

namespace DTO
{
    public static class ConvertDateTypes
    {
        //// extension method
        public static int ToInt(this object numb)
        {
            return Convert.ToInt32(numb);
        }

        public static DateTime ToDateTime(this object date)
        {
            return Convert.ToDateTime(date);
        }

        //public static int ToTypeID(this KindOfTask kindOfTask)
        //{
        //    if (kindOfTask == KindOfTask.Backlog) return 0;
        //    if (kindOfTask == KindOfTask.Resolved) return 1;

        //    return 2;
        //}

        //public static KindOfTask ToKindOfTask(this object idKind)
        //{
        //    return (KindOfTask)Convert.ToInt32(idKind);
        //}
    }
}
