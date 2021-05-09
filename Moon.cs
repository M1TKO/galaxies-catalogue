namespace PP_Galaxies_Catalogue {
    public class Moon {

        public string MoonName { get; set; }

        public Planet Planet { get; set; }

        public Moon(string moonname) {
            this.MoonName = moonname;
        }
    }

}
