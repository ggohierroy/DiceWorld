App.Router.map(function () {
    this.resource('home', { path: '/home' }, function() {
        this.route('new', { path: '/new' });
        this.route('hotness', { path: '/hotness' });
        this.route('upcoming', { path: '/upcoming' });
    });
    this.route('checkout', { path: '/checkout' });
    this.route('about', { path: '/about' });
    this.route('contact', { path: '/contact' });
    this.route('register', { path: '/register' });
    this.route('cart', { path: '/cart' });
    this.resource('catalogue', { path: '/catalogue' }, function() {
        this.resource('boardGame', { path: '/boardGame/:boardGame_id' });
    });
});