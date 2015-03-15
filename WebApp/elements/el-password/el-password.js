(function () {
    "use strict";

    var password;

    Polymer({
        passId: undefined,
        name: undefined,
        username: undefined,
        password: undefined,
        data: undefined,
        ready: function () {
            this.passId = this.data.PassId;
            this.name = this.data.Name;
            this.username = this.data.Username;
        },
        Toggle: function () {
            var section = this.$.pass.querySelector("section:last-child");

            if (section.getAttribute("class") === null) {
                section.setAttribute("class", "hidden");
            } else {
                section.removeAttribute("class");
            }
        },
        ShowPass: function () {
            password = this.$.password;

            this.$.xhr.request({
                url: "/home/showpassword",
                params: { strId: this.passId },
                callback: function (pass) {
                    pass = JSON.parse(pass);
                    password.innerHTML = "<core-icon icon='lock-outline'></core-icon><p>" + pass + "</p><a href='' onclick=\"$(this).zclip({ path:'ZeroClipboard.swf', copy:'" + pass + "' })\"><core-icon icon='content-copy'></core-icon></a>";
                }
            });
        },
        DeletePass: function () {
            this.$.xhr.request({
                url: "/home/deletepass",
                params: { strId: this.passId },
                callback: function() { ChangeView("home", document.querySelector("view-home").username); }
            });
        }
    });
})()