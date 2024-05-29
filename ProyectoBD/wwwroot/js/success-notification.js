document.addEventListener("DOMContentLoaded", function () {
    var successNotification = document.getElementById("success-notification");
    if (successNotification) {
        var successMessage = successNotification.getAttribute("data-success-message");
        if (successMessage && successMessage.trim() !== "") {
            successNotification.innerHTML = successMessage;
            successNotification.style.display = "block";
            setTimeout(function () {
                successNotification.style.display = "none";
            }, 3000); // Ocultar después de 3 segundos
        }
    }
});
