using System.Collections.Generic;

namespace PP_Galaxies_Catalogue {
    public class Planet {
        public string PlanetName { get; set; }

        public bool HasLife { get; set; }

        public string PlanetType { get; set; }

        public List<Moon> Moons;

        public Planet(string name, string type, bool hasLife) {
            PlanetName = name;
            PlanetType = type;
            HasLife = hasLife;
            this.Moons = new List<Moon>();
        }

    }
}