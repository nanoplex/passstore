(function () {
    "use strict";

    var button,
        login;
    Polymer({
        username: undefined,
        password: undefined,

        ready: function () {
            button = this.$.btnLogin;
            login = this.$.login;
        },
        login: function (e) {

            if (e.detail.response !== false) {

                button.setAttribute("class", "OK");
                button.innerHTML = "<core-icon icon='check'></core-icon>";

                login.setAttribute("class", "hide");
                setTimeout(function () {
                    ChangeView("home", e.detail.response);
                }, 500);

            }
            else {

                button.setAttribute("class", "BAD");
                button.innerHTML = "<core-icon icon='close'></core-icon>";

                setTimeout(function () {
                    button.innerHTML = "<core-icon icon='lock-open'></core-icon>";
                }, 3500);

            };

        }
    });
})();