using Exercice3_TDD.Core;

namespace Exercice3_TDD.Tests;

[TestClass]
public class RechercheVilleTests
{
    /*
    [TestMethod]
        public void Rechercher_MoinsDe2Caracteres_LeveNotFoundException()
        {
            // Arrange
            var sut = CreateSut();

            // Act + Assert
            Assert.Throws<NotFoundException>(() => sut.Rechercher("A"));
        }

        private static RechercheVille CreateSut()
            => new RechercheVille(AllCities());

        private static List<string> AllCities() => new List<string>
        {
            "Paris","Budapest","Skopje","Rotterdam","Valence","Vancouver","Amsterdam","Vienne",
            "Sydney","New York","Londres","Bangkok","Hong Kong","Dubaï","Rome","Istanbul"
        };
    */
    
    
    [TestMethod]
    public void Rechercher_MoinsDe2Caracteres_LeveNotFoundException()
    {
        var sut = CreateSut();
        Assert.Throws<NotFoundException>(() => sut.Rechercher("A"));
    }

    [TestMethod]

    public void Rechercher_va_Insensiblecase_RetourneValenceEtVancouver()
    {
        var sut = CreateSut();
        var result = sut.Rechercher("va");
        CollectionAssert.AreEqual(new List<string> { "Valence", "Vancouver" }, result);
    }

    [TestMethod]
    public void Rechercher_pe_RetourneBudapest()
    {
        var sut = CreateSut();
        var result = sut.Rechercher("pe");
        CollectionAssert.AreEqual(new List<string> { "Budapest" }, result);
    }

    [TestMethod]
    public void Rechercher_Asterisque_RetourneToutesLesVilles()
    {
        var sut = CreateSut();
        var result = sut.Rechercher("*");
        CollectionAssert.AreEqual(AllCities(), result);
    }

    private static RechercheVille CreateSut() => new RechercheVille(AllCities());

    private static List<string> AllCities() => new List<string>
    {
        "Paris","Budapest","Skopje","Rotterdam","Valence","Vancouver","Amsterdam","Vienne",
          "Sydney","New York","Londres","Bangkok","Hong Kong","Dubaï","Rome","Istanbul"
    };

}
