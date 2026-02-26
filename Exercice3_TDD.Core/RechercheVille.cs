using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice3_TDD.Core
{
    public class RechercheVille
    {
        private List<string> _villes;

        public RechercheVille(List<string> villes)
        {
            _villes = villes ?? throw new ArgumentNullException(nameof(villes));
        }

        public List<string> Rechercher(string mot)
        {
            throw new NotImplementedException();

            /*if (mot == "*")
                return _villes.ToList();

            if (string.IsNullOrWhiteSpace(mot) || mot.Length < 2)
                throw new NotFoundException("Le texte de recherche doit contenir au moins 2 caractères.");

            return _villes
                .Where(v => v.IndexOf(mot,StringComparison.OrdinalIgnoreCase) >= 0) 
                .ToList();*/
        }
    }
}
