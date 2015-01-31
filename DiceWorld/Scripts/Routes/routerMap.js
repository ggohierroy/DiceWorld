App.Router.map(function () {
    this.route('home', { path: '/home' });
    this.route('checkout', { path: '/checkout' });
    this.route('about', { path: '/about' });
    this.route('contact', { path: '/contact' });
    this.resource('catalogue', { path: '/catalogue' }, function() {
        this.resource('boardGame', { path: '/boardGame/:boardGame_id' });
    });
});