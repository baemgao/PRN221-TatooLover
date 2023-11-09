document.getElementById("searchDate").addEventListener("change", function () {
    var dateValue = this.value;
    localStorage.setItem("savedDate", dateValue);
});
window.onload = function () {
    var savedDate = localStorage.getItem("savedDate");
    if (savedDate) {
        document.getElementById("searchDate").value = savedDate;
    }
};
window.addEventListener("beforeunload", function () {
    localStorage.removeItem("savedDate");
});