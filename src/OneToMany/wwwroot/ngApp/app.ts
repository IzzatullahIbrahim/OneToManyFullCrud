namespace OneToMany {

    angular.module('OneToMany', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: OneToMany.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('about', {
                url: '/about/:id',
                templateUrl: '/ngApp/views/about.html',
                controller: OneToMany.Controllers.AboutController,
                controllerAs: 'controller'
            })
            .state(`addCategory`, {
                url: `/addCategory`,
                templateUrl: `/ngApp/views/addCategory.html`,
                controller: OneToMany.Controllers.AddCategoryController,
                controllerAs:`controller`
            })
            .state(`addMovie`, {
                url: `/addMovie`,
                templateUrl: `ngApp/views/addMovie.html`,
                controller: OneToMany.Controllers.AddMovieController,
                controllerAs: `controller`
            })
            .state(`editMovie`, {
                url: `/editMovie/:id`,
                templateUrl: `ngApp/views/editMovie.html`,
                controller: OneToMany.Controllers.EditMovieController,
                controllerAs:`controller`
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });

    

}
