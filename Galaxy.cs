using System.Collections.Generic;

namespace PP_Galaxies_Catalogue {
    public class Galaxy {
        public List<Star> Stars { get; set; }

        public Galaxy() {
            Stars = new List<Star>();
        }

        public string GalaxyName { get; set; }

        public float GalaxyAge { get; set; }

        public string AgeMagnitude { get; set; }

        public GalaxyType GalaxyType { get; set; }
    }
}
