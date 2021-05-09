using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PP_Galaxies_Catalogue {

    /** 
        TEST COMMANDS:

        add galaxy [Milky Way] elliptical 13.2B
        add galaxy [oven] lenticular 15.4M
        add star [Milky Way] [Sun] 0.99 1.98 5778 1.00
        add star [oven] [zvezda] 1.4 1.4 6200 3
        add planet [Sun] [Earth] terrestrial yes
        add planet [Sun] [Jupiter] ice giant no
        add planet [zvezda] [planeta] planetar no
        add moon [Earth] [Moon]
        add moon [Earth] [Poon]
        add moon [planeta] [luna]
        list galaxies
        list moons
        list planets
        list stars
        stats
        print [Milky Way]
        exit

     */

    class GalaxiesCatalogueApp {
        static List<Galaxy> Galaxies = new List<Galaxy>();
        static List<Planet> Planets = new List<Planet>();
        static List<Star> Stars = new List<Star>();
        static List<Moon> Moons = new List<Moon>();

        static void Main() {

            while (true) {
                string input = Console.ReadLine();
                string[] command = SplitCommandInput(input);

                if (input == "exit" || String.IsNullOrEmpty(input)) {
                    break;
                } else if (command[0] == "add") {
                    if (command[1] == "galaxy") {
                        CreateNewGalaxy(command[2], command[3], command[4]);
                    } else if (command[1] == "star") {
                        CreateNewStar(command[2], command[3], command[6], command[4], command[7], command[5]);
                    } else if (command[1] == "planet") {
                        CreateNewPlanet(command[2], command[3], command[4], command[5]);
                    } else if (command[1] == "moon") {
                        CreateNewMoon(command[2], command[3]);
                    }
                } else if (command[0] == "stats") {
                    PrintStatsCommand();
                } else if (command[0] == "list") {
                    if (command[1] == "galaxies") {
                        GalaxiesListing();
                    } else if (command[1] == "stars") {
                        StarsListing();
                    } else if (command[1] == "planets") {
                        PlanetsListing();
                    } else if (command[1] == "moons") {
                        MoonsListing();
                    }
                } else if (command[0] == "print") {
                    GalaxyPrint(command[1]);
                }
            }

            void CreateNewGalaxy(string newGalaxyName, string newGalaxyType, string newGalaxyAge) {
                Galaxy newGalaxy = new Galaxy();
                newGalaxy.GalaxyName = newGalaxyName;
                newGalaxy.GalaxyType = (GalaxyType)Enum.Parse(typeof(GalaxyType), newGalaxyType, true);
                newGalaxy.AgeMagnitude = newGalaxyAge[newGalaxyAge.Length - 1].ToString();
                newGalaxy.GalaxyAge = float.Parse(newGalaxyAge.Substring(0, newGalaxyAge.Length - 1));
                Galaxies.Add(newGalaxy);
            }

            void CreateNewStar(string newGalaxyName, string newStarName, string newTemp, string newMass, string newLumin, string newSize) {
                float tmass = float.Parse(newMass);
                float tsize = float.Parse(newSize);
                int ttemp = int.Parse(newTemp);
                float tlumin = float.Parse(newLumin);
                Star newStar = new Star(newStarName, tmass, tsize, ttemp, tlumin);

                foreach (Galaxy g in Galaxies) {
                    if (g.GalaxyName == newGalaxyName) {
                        g.Stars.Add(newStar);
                    }
                }
                Stars.Add(newStar);
            }

            void CreateNewPlanet(string newStarName, string newPlanetName, string newPlanetType, string newPlanethabbit) {
                bool isHabbitable = newPlanethabbit == "yes";
                Planet newPlanet = new Planet(newPlanetName, newPlanetType, isHabbitable);

                foreach (Star s in Stars) {
                    if (s.StarName == newStarName) {
                        s.Planets.Add(newPlanet);
                    }
                }
                Planets.Add(newPlanet);
            }

            void CreateNewMoon(string newPlanetname, string newMoonName) {
                Moon newMoon = new Moon(newMoonName);

                foreach (Planet p in Planets) {
                    if (p.PlanetName == newPlanetname) {
                        newMoon.Planet = p;
                        p.Moons.Add(newMoon);
                    }
                }
                Moons.Add(newMoon);
            }

            void GalaxiesListing() {
                Console.WriteLine("--- List of all researched galaxies ---");

                foreach (Galaxy g in Galaxies) {
                    Console.WriteLine(g.GalaxyName);
                }

                Console.WriteLine("--- End of galaxies list ---");
            }

            void StarsListing() {
                Console.WriteLine("--- List of all researched stars ---");

                foreach (Star s in Stars) {
                    Console.WriteLine(s.StarName);
                }

                Console.WriteLine("--- End of stars list ---");
            }

            void PlanetsListing() {
                Console.WriteLine("--- List of all researched planets ---");

                foreach (Planet p in Planets) {
                    Console.WriteLine(p.PlanetName);
                }

                Console.WriteLine("--- End of planets list ---");
            }

            void MoonsListing() {
                Console.WriteLine("--- List of all researched moons ---");

                foreach (Moon m in Moons) {
                    Console.WriteLine(m.MoonName);
                }

                Console.WriteLine("--- End of moons list ---");
            }

            string[] SplitCommandInput(string input) {
                StringBuilder builder = new StringBuilder();
                var parts = new List<string>();

                for (int i = 0; i < input.Length; i++) {
                    if (input[i] == ' ') {
                        parts.Add(builder.ToString());
                        builder.Clear();
                        continue;
                    }
                    if (input[i] == '[') {
                        i++;
                        while (input[i] != ']') {
                            builder.Append(input[i]);
                            i++;
                        }
                        parts.Add(builder.ToString());
                        builder.Clear();
                        i++;
                        continue;
                    }
                    builder.Append(input[i]);
                }
                parts.Add(builder.ToString());

                return parts.ToArray();
            }

            void GalaxyPrint(string GalaxyName) {
                Console.WriteLine($"--- Data for {GalaxyName} galaxy ---");
                Galaxy galaxy = Galaxies.FirstOrDefault(g => g.GalaxyName == GalaxyName);
                Console.WriteLine($"Type:{galaxy.GalaxyType}");
                Console.WriteLine($"Age:{galaxy.GalaxyAge}{galaxy.AgeMagnitude}");
                Console.WriteLine("Stars:");

                foreach (Star s in galaxy.Stars) {
                    Console.WriteLine($"    -  Name:{s.StarName}");
                    Console.WriteLine($"       Class:{s.StarClass} ({s.StarMass},{s.StarSize},{s.StarTemp},{s.StarLuminosity:f2})");

                    Console.WriteLine($"       Planets:");
                    foreach (Planet p in s.Planets) {
                        Console.WriteLine($"         ■   Name:{p.PlanetName}");
                        Console.WriteLine($"             Type:{p.PlanetType}");
                        var isHabbitable = p.HasLife ? "yes" : "no";
                        Console.WriteLine($"             Support life:{isHabbitable}");

                        Console.WriteLine($"             Moons:");
                        foreach (Moon m in p.Moons) {
                            Console.WriteLine($"                    ■    {m.MoonName}");
                        }

                    }
                    Console.WriteLine($"--- End of data for {GalaxyName} galaxy ---");
                }
            }

            void PrintStatsCommand() {
                Console.WriteLine("--- Stats ---");
                Console.WriteLine($"Galaxies: {Galaxies.Count}");
                Console.WriteLine($"Stars: {Stars.Count}");
                Console.WriteLine($"Planets: {Planets.Count}");
                Console.WriteLine($"Moons: {Moons.Count}");
                Console.WriteLine("--- End of Stats ---");
            }
        }
    }
}