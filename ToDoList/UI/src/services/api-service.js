class ApiService {

    createCategory(categoryName) {
        $.ajax({
            url: '/Home/CreateCategory',
            type: 'POST',
            data: { Name: categoryName },
            dataType: 'html',
            success: function () {
                $(".invalid-feedback").hide();
                $(".valid-feedback").show();
                $(".valid-feedback").html(`Category ${categoryName} successfully created`)
            },
            error: function (xhr, ajaxOptions, thrownError) {
                $(".valid-feedback").hide();
                $(".invalid-feedback").show();
                $(".invalid-feedback").html(xhr.responseText)
            }
        });




    }
}

export default ApiService;