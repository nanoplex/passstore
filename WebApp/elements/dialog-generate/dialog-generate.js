(function () {
    "use strict";

    var Letters = ["a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "z"],
        LettersCased = ["A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Z"],
        Numbers = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"],
        Symbols = ["!", "#", "$", "%", "&", "'", "(", ")", "*", "+", ",", ".", "-", "/", ":", ";", "<", ">", "=", "?", "@@", "[", "]", "\\", "^", "_", "{", "}", "|", "~"],
        SpecialSymbols = ["¢", "£", "¤", "¥", "¦", "§", "µ", "©", "®"];

    Polymer({
        letters: false,
        lettersCased: false,
        numbers: false,
        symbols: false,
        length: 5,
        password: "",
        ready: function () {

        },
        Toggle: function () {
            if (this.getAttribute("class") === null) {
                this.setAttribute("class", "hide");
            } else {
                this.removeAttribute("class");
            }
        },
        Generate: function () {
            this.Toggle();

            var add = document.querySelector("view-home").shadowRoot.getElementById("add");

            for (var i = 0; i < this.length; i++) {
                this.GetRandomChar();
            }

            add.password = this.password;
            setTimeout(function () {
                add.Toggle();
            }, 500);
        },
        GetRandomChar: function () {
            var Selected = [],
                selCount = 0;

            if (this.letters) {
                for (var i = 0; i < Letters.length; i++) {
                    Selected[selCount] = Letters[i];
                    selCount++;
                }
            }
            if (this.lettersCased) {
                for (var i = 0; i < LettersCased.length; i++) {
                    Selected[selCount] = LettersCased[i];
                    selCount++;
                }
            }
            if (this.numbers) {
                for (var i = 0; i < Numbers.length; i++) {
                    Selected[selCount] = Numbers[i];
                    selCount++;
                }
            }
            if (this.symbols) {
                for (var i = 0; i < Symbols.length; i++) {
                    Selected[selCount] = Symbols[i];
                    selCount++;
                }
            }
            this.password += Selected[Math.floor(Math.random() * selCount)];
        }
    });
})()