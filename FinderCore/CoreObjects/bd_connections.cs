﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderCore
{
    public static class bd_connections      //Желательно исправить некоррекное именование класса (Мясников)
    {
        public static FinderEntities connection = new FinderEntities();
    }
}
