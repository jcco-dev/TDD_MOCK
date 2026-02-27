using Exercice4_TDD.Core;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Exercice4_TDD.Tests
{
    // Fake (mock) : renvoie une séquence contrôlée de pins
    public class FakeGenerateur : IGenerateur
    {
        private readonly Queue<int> _values;

        public FakeGenerateur(params int[] values)
        {
            _values = new Queue<int>(values);
        }

        public int RandomPin(int max)
        {
            if (_values.Count == 0)
                throw new InvalidOperationException("No more fake values configured.");

            int v = _values.Dequeue();

            // Option : sécuriser pour éviter des valeurs impossibles
            if (v < 0 || v > max)
                throw new ArgumentOutOfRangeException(nameof(v), $"Fake value {v} is out of allowed range 0..{max}");

            return v;
        }
    }
}
