using System.Collections.Generic;

namespace PP_Galaxies_Catalogue {
    public class Star {
        public string StarName {
            get;
            set;
        }

        public StarClass StarClass {
            get;
            private set;
        }

        public float StarLuminosity {
            get;
            private set;
        }

        public float StarMass {
            get;
            private set;
        }

        public int StarTemp {
            get;
            private set;
        }

        public float StarSize {
            get;
            private set;
        }

        public List<Planet> Planets;
        public Star(string name, float mass, float size, int temp, float luminosity) {
            this.StarName = name;
            StarMass = mass;
            StarSize = size / 2;
            StarTemp = temp;
            StarLuminosity = luminosity;

            if (
              StarTemp >= 30000 &&
              StarLuminosity >= 30000 &&
              StarMass >= 16 &&
              StarSize >= 6.6
            ) {
                StarClass = StarClass.O;
            } else if (
              StarTemp >= 10000 &&
              StarLuminosity >= 25 &&
              StarMass >= 2.1 &&
              StarSize >= 1.8
            ) {
                StarClass = StarClass.B;
            } else if (StarTemp >= 7500 &&
              StarLuminosity >= 5 &&
              StarMass >= 1.4 &&
              StarSize >= 1.4) {
                StarClass = StarClass.A;
            } else if (StarTemp >= 6000 &&
              StarLuminosity >= 1.5 &&
              StarMass >= 1.04 &&
              StarSize >= 1.15) {
                StarClass = StarClass.F;
            } else if (StarTemp >= 5200 &&
              StarLuminosity >= 0.6 &&
              StarMass >= 0.8 &&
              StarSize >= 0.96) {
                StarClass = StarClass.G;
            } else if (StarTemp >= 3700 &&
              StarLuminosity > 0.08 &&
              StarMass >= 0.45 &&
              StarSize > 0.7) {
                StarClass = StarClass.K;
            } else if (
              StarTemp >= 2400 &&
              StarLuminosity <= 0.08 &&
              StarMass >= 0.08 &&
              StarSize <= 0.7
            ) {
                StarClass = StarClass.M;
            }

            this.Planets = new List<Planet>();
        }
    }
}