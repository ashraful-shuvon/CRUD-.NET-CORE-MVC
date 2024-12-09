$(document).ready(function () {
    loadOrders();

    function loadOrders() {
        $.get("/Orders/GetOrders", function (data) {
            // Render table with data
        });
    }

    $("#addOrderBtn").click(function () {
        // Show modal for adding order
    });

    $("#orderModal").on("submit", "form", function (e) {
        e.preventDefault();
        // Submit via AJAX
    });
});
