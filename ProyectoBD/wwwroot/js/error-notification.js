document.addEventListener("DOMContentLoaded", function () {
    var errorNotification = document.getElementById("error-notification");
    if (errorNotification && errorNotification.innerText.trim() !== "") {
        errorNotification.style.display = "block";
    }
});
