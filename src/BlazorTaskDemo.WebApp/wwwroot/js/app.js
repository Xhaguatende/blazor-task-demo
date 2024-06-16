// wwwroot/scripts.js
window.setMinDate = (elementId, minDate) => {
    var element = document.getElementById(elementId);
    if (element) {
        var inputElement = element.querySelector('input');
        if (inputElement) {
            inputElement.setAttribute('min', minDate);
        }
    }
};
