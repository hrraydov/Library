var viewModel = function () {
    var self = this;

    self.loadBooks = function (name, fromPages, toPages, genre, pageNumber) {
        $.getJSON("/books/search", { name: name, fromPages: fromPages, toPages: toPages, genre: genre, pageNumber: pageNumber }, function (data) {
            self.books(data);
        });
    };

    self.selected = {
        name: ko.observable(),
        fromPages: ko.observable(),
        toPages: ko.observable(),
        genre: ko.observable()
    };

    self.loadGenres = function () {
        $.getJSON("/books/genres", function (data) {
            self.genres(data);
        });
    };

    self.search = function () {
        self.loadBooks(self.selected.name(), self.selected.fromPages(), self.selected.toPages(), self.selected.genre(), 0);
        self.page(0);
    };

    self.pagedSearch = function () {
        self.loadBooks(self.selected.name(), self.selected.fromPages(), self.selected.toPages(), self.selected.genre(), self.page());
    };

    self.goToNextPage = function () {
        self.page(self.page() + 1);
        console.log('next page');
        console.log(self.page());
        self.pagedSearch();
        if (self.books().length == 0) {
            self.page(self.page() - 1);
        }
    };

    self.goToPreviousPage = function () {
        self.page(self.page() - 1);
        console.log('previous page');
        if (self.page() < 0) {
            self.page(0);
        }
        console.log(self.page());
        self.pagedSearch();
    }

    self.page = ko.observable(0);

    self.genres = ko.observableArray();

    self.books = ko.observableArray();

};

var vm = new viewModel();
ko.applyBindings(vm);
vm.search();
vm.loadGenres();