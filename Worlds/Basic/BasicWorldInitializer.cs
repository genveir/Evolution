﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worlds.Basic
{
    public class BasicWorldInitializer : IWorldInitializer<BasicWorld>
    {
        public BasicWorld CreateInitialWorld() => new();
    }
}
