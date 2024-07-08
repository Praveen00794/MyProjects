<script>
    $(document).ready(function () {
        $('#redirectToProducts').click(function (e) {
            e.preventDefault(); // Prevent default click behavior (loading a new page)

            $.ajax({
                url: '/Customer/Index', // URL of your controller action
                type: 'GET', // HTTP method (GET, POST, etc.)
                success: function (result) {
                    // Optional: Handle success response if needed
                    console.log('Redirected successfully');
                    // Navigate to the new page using JavaScript
                   
                },
                error: function (xhr, status, error) {
                    // Handle errors if any
                    console.error('Error redirecting:', error);
                }
            });
        });
    });
</script>
