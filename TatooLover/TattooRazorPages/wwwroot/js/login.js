document.getElementById("Email").addEventListener("change", function () {
    var emailValue = this.value;
    localStorage.setItem("savedEmail", emailValue);
});

document.getElementById("Password").addEventListener("change", function () {
    var passwordValue = this.value;
    localStorage.setItem("savedPassword", passwordValue);
});
window.onload = function () {
    var savedEmail = localStorage.getItem("savedEmail");
    var savedPassword = localStorage.getItem("savedPassword");
    if (savedEmail) {
        document.getElementById("Email").value = savedEmail;
    }
    if (savedPassword) {
        document.getElementById("Password").value = savedPassword;
    }
};
