function formata(campo, mask, evt) {

    if (document.all) { // Internet Explorer
        key = evt.keyCode;
    }
    else { // Nestcape
        key = evt.which;
    }

    string = campo.value;
    i = string.length;

    if (i < mask.length) {
        if (mask.charAt(i) == '§') {
            return (key > 47 && key < 58);
        } else {
            if (mask.charAt(i) == '!') { return true; }
            for (c = i; c < mask.length; c++) {
                if (mask.charAt(c) != '§' && mask.charAt(c) != '!')
                    campo.value = campo.value + mask.charAt(c);
                else if (mask.charAt(c) == '!') {
                    return true;
                } else {
                    return (key > 47 && key < 58);
                }
            }
        }
    } else return false;
}
