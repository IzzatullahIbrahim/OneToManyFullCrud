namespace OneToMany.Controllers {

    export class HomeController {
        public movies;

        public deleteMovie(id: number) { 
            this.$http.delete(`/api/movies/` + id).then((response) => {
                this.$state.reload();
            })
        }

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            this.$http.get(`/api/movies`).then((response) => {
                if (response.status == 200) {
                    this.movies = response.data;
                } else {
                    console.error("AHHHH the API doesnt work!");
                }

            })
        }
    }

    export class AboutController {
        public category;
        
        constructor(private $stateParams: ng.ui.IStateParamsService, private $http: ng.IHttpService) {
            let cId = this.$stateParams[`id`];
            this.$http.get(`/api/categories/` + cId).then((response) => {
                this.category = response.data;
            })
        }
    }

    export class AddCategoryController {
        public cat;

        public addCat() {
            this.$http.post(`/api/categories/`, this.cat).then((response) => {
                this.$state.go(`home`);
            })
        }

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {

            // empty because we dont want the http service on page load, or reroute on page load. 
        }
        
    }

    export class AddMovieController {
        public movie;
        public categories;

        public addMovie() {
            this.$http.post(`/api/movies`, this.movie).then((response) => {
                this.$state.go(`home`);
            })
        }

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService ) {
            this.$http.get(`/api/categories`).then((response) => {
                this.categories = response.data;
            }) 
        }
    }

    export class EditMovieController {
        public movie;
        public category;
        public editMovie() {
            this.$http.post(`/api/movies`, this.movie).then((response) => {
                this.$state.go(`home`);
            });
        }

        constructor(private $stateParams: ng.ui.IStateParamsService, private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            let movieId = this.$stateParams[`id`];
            this.$http.get(`/api/movies/` + movieId).then((response) => {
                this.movie = response.data;
            })
            console.log("Hitting the edit controller");
            //this.$http.get(`/api/categories`).then((response) => {
            //    this.category = response.data;
            //})
        }
    }
}
