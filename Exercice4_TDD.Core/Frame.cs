using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice4_TDD.Core
{
    public class Frame
    {
        private int _score;
        private readonly bool _lastFrame;
        private readonly IGenerateur _generateur;
        private readonly List<Roll> _rolls = new();

        public Frame(IGenerateur generateur, bool lastFrame)
        {
            _lastFrame = lastFrame;
            _generateur = generateur;
        }

        public int Score => _score;
        public IReadOnlyList<Roll> Rolls => _rolls;

        public bool MakeRoll()
        {
            /*if (!_lastFrame && _rolls.Count >= 2)
                return false;

            //throw new NotImplementedException();

            int pins = _generateur.RandomPin(10);
            _rolls.Add(new Roll(pins));
            _score += pins;

            if (!_lastFrame && _rolls.Count >= 2)
                return false;

            if (!_lastFrame && _rolls.Count == 1 && _rolls[0].Pins == 10)
                return false;

            // Simple frame : après 1er lancer, on peut continuer
            return true;
            //return pins > 0;*/

            //------------------

            // Guards: max rolls
            if (!_lastFrame)
            {
                // frame standard : max 2, ou 1 si strike
                if (_rolls.Count >= 2) return false;
                if (_rolls.Count == 1 && _rolls[0].Pins == 10) return false;
            }
            else
            {
                // dernier frame : max 4 (selon l'énoncé)
                if (_rolls.Count >= 4) return false;

                // Si on a déjà 2 rolls et pas strike/spare, pas de 3e
                if (_rolls.Count == 2)
                {
                    int first = _rolls[0].Pins;
                    int second = _rolls[1].Pins;
                    bool strike = first == 10;
                    bool spare = (first + second) == 10;

                    if (!strike && !spare)
                        return false;
                }
            }

            // Make roll
            int maxPins = 10; // simplification (on ne gère pas pins restants)
            int pins = _generateur.RandomPin(maxPins);

            _rolls.Add(new Roll(pins));
            _score += pins;

            // Retourne si un nouveau roll est autorisé
            if (!_lastFrame)
            {
                if (_rolls.Count == 1 && _rolls[0].Pins == 10) return false;
                if (_rolls.Count >= 2) return false;
                return true;
            }
            else
            {
                if (_rolls.Count >= 4) return false;

                // après 2 rolls, si pas strike/spare -> stop
                if (_rolls.Count == 2)
                {
                    int first = _rolls[0].Pins;
                    int second = _rolls[1].Pins;
                    bool strike = first == 10;
                    bool spare = (first + second) == 10;

                    if (!strike && !spare)
                        return false;
                }

                return true;
            }
        }
    }
}
