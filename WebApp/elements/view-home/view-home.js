(function () {
    "use strict";

    Polymer({
        passwords: undefined,
        username: undefined,
        ready: function () {

        },
        logout: function () {
            this.$.logout.request({ url: "/home/logout", params: {}, callback: function (e) { ChangeView("login"); } });
        },
        addClick: function () {
            this.$.addButton.setAttribute("class", "hide");
            this.$.add.Toggle();
        },
        handlePasswords: function (res) {
            this.passwords = res.detail.response;
        }
    });
})()