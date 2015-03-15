(function () {
    "use strict";

    var self;

    Polymer({
        name: undefined,
        username: undefined,
        password: undefined,

        ready: function () {
            self = this;
        },
        Toggle: function () {
            if (this.getAttribute("class") === null) {
                this.setAttribute("class", "hide");
            } else {
                this.removeAttribute("class");
            }
        },
        Add: function () {
            this.$.xhr.request({
                url: "/home/addpass",
                params: { name: this.name, username: this.username, password: this.password },
                callback: function (e) {
                    var viewHome = document.querySelector("view-home").shadowRoot;

                    viewHome.getElementById("add").Toggle();
                    setTimeout(function () {
                        ChangeView("home", document.querySelector("view-home").username);
                    }, 500);

                }
            });
        },
        Generate: function () {
            this.Toggle();
            setTimeout(function () {
                document.querySelector("view-home").shadowRoot.getElementById("generate").Toggle();
            }, 500);
        }
    });
})()