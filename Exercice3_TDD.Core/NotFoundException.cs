using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice3_TDD.Core
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
}
