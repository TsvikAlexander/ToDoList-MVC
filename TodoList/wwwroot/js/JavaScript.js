'use strict';

let toggleDiv = function (id) {
    let tag = document.getElementById(id);
    if (tag.style.display == 'none')
        tag.style.display = 'block';
    else
        tag.style.display = 'none';
};