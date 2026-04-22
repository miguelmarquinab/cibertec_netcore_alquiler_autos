document.addEventListener("DOMContentLoaded", () => {
    const alerts = document.querySelectorAll(".alert-success");
    if (alerts.length > 0) {
        setTimeout(() => {
            alerts.forEach(a => a.style.display = "none");
        }, 3000);
    }
});